using System.Collections.Generic;
using System.Threading.Tasks;
using NewVidly.Models;
using NewVidly.Repositories;

namespace NewVidly.Services
{
    public class MoviesService : IMoviesService
    {
        IMoviesRepository _moviesRepository;
        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _moviesRepository.GetAllAsync();
        }
        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _moviesRepository.GetByIdAsync(id);
        }
    }
}