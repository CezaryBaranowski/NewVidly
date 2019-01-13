using NewVidly2.Controllers.DTOs;
using NewVidly2.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewVidly2.Services
{
    public interface IMoviesService
    {
        Task<List<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<MovieDto> SaveMovieAsync(MovieDto movie);
        Task UpdateMovieAsync(int id, MovieDto movie);
        Task DeleteMovieAsync(int id);
        Genre GetGenreById(byte genreId);
    }
}