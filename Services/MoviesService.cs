using System.Collections.Generic;
using System.Threading.Tasks;
using NewVidly2.Models;
using NewVidly2.Repositories;

namespace NewVidly2.Services
{
    public class MoviesService : IMoviesService
    {
        IMoviesRepository _moviesRepository;
        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<Movie> SaveMovieAsync(Movie movie)
        {
            await _moviesRepository.SaveMovieAsync(movie);
            return movie;
        }
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _moviesRepository.GetAllAsync();
        }
        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _moviesRepository.GetByIdAsync(id);
        }

        public async Task UpdateMovieAsync(int id, Movie movie)
        {
            await _moviesRepository.UpdateMovieAsync(id, movie);
        }

         public async Task DeleteMovieAsync(Movie movie)
        {
            await _moviesRepository.DeleteMovieAsync(movie);
        }

        public Genre GetGenreById(byte genreId)
        {
            return _moviesRepository.GetGenreById(genreId);
        }
    }
}