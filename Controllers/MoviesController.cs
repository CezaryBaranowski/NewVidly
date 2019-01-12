using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewVidly2.Controllers.DTOs;
using NewVidly2.Core;
using NewVidly2.Core.Models;
using NewVidly2.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewVidly2.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IMoviesService moviesService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _moviesService = moviesService;
            _mapper = mapper;
        }

        [HttpGet("/api/movies")]
        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            var movies = await _moviesService.GetAllMoviesAsync();

            var result = _mapper.Map<List<Movie>, List<MovieDto>>(movies);

            return result;
        }

        [HttpGet("/api/movies/{id}")]
        public async Task<MovieDto> GetMovie(int id)
        {
            var movie = await _moviesService.GetMovieAsync(id);

            var result = _mapper.Map<Movie, MovieDto>(movie);
            return result;
        }

        [HttpPost("/api/movies")]
        public async Task<IActionResult> CreateMovie([FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            //to service
            movie.NumberAvailable = movieDto.NumberInStock;
            movie.DateAdded = DateTime.Now;
            movie.Genre = _moviesService.GetGenreById(movieDto.GenreId);
            await _moviesService.SaveMovieAsync(movie);

            var result = _mapper.Map<Movie, MovieDto>(movie);
            return Ok(result);
        }

        [HttpPut("/api/movies/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);

            var movieToUpdate = await _moviesService.GetMovieAsync(id);
            if (movieToUpdate == null)
                return NotFound();

            _mapper.Map(movie, movieToUpdate);
            movieToUpdate.Genre = _moviesService.GetGenreById(movieToUpdate.GenreId);
            movieToUpdate.DateAdded = DateTime.Now;

            await _moviesService.UpdateMovieAsync(id, movie);

            var updatedMovie = await _moviesService.GetMovieAsync(movie.Id);
            var result = _mapper.Map<Movie, MovieDto>(updatedMovie);
            return Ok(updatedMovie);
        }

        [HttpDelete("/api/movies/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movieToDelete = await _moviesService.GetMovieAsync(id);
            if (movieToDelete == null)
                return NotFound();


            await _moviesService.DeleteMovieAsync(movieToDelete);
            return Ok(id);
        }

    }
}