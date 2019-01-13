using AutoMapper;
using NewVidly2.Controllers.DTOs;
using NewVidly2.Core;
using NewVidly2.Core.Models;
using NewVidly2.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewVidly2.Services
{
    public class MoviesService : IMoviesService
    {
        IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; }

        public MoviesService(IMoviesRepository moviesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _moviesRepository.GetAllAsync();
            var result = _mapper.Map<List<Movie>, List<MovieDto>>(movies);
            return result;
        }
        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _moviesRepository.GetByIdAsync(id);
            var result = _mapper.Map<Movie, MovieDto>(movie);
            return result;
        }

        public async Task<MovieDto> SaveMovieAsync(MovieDto movie)
        {
            var newMovie = _mapper.Map<MovieDto, Movie>(movie);
            newMovie.NumberAvailable = movie.NumberInStock;
            newMovie.DateAdded = DateTime.Now;
            newMovie.Genre = _moviesRepository.GetGenreById(movie.GenreId);
            await _moviesRepository.AddMovieAsync(newMovie);
            await _unitOfWork.CompleteAsync();

            var savedMovie = await _moviesRepository.GetByIdAsync(newMovie.Id);
            var result = _mapper.Map<Movie,MovieDto>(savedMovie);
            return result;
        }

        public async Task UpdateMovieAsync(int id, MovieDto movieDto)
        {
             var movieToUpdate = await _moviesRepository.GetByIdAsync(id);

            _mapper.Map(movieDto, movieToUpdate);
            movieToUpdate.Genre = _moviesRepository.GetGenreById(movieToUpdate.GenreId);
            movieToUpdate.DateAdded = DateTime.Now;
            await _unitOfWork.CompleteAsync();

            var updatedMovie = await _moviesRepository.GetByIdAsync(movieToUpdate.Id);
            var result = _mapper.Map<Movie, MovieDto>(updatedMovie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            await _moviesRepository.DeleteMovieAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public Genre GetGenreById(byte genreId)
        {
            return _moviesRepository.GetGenreById(genreId);
        }
    }
}