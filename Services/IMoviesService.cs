using System.Collections.Generic;
using System.Threading.Tasks;
using NewVidly.Models;

namespace NewVidly.Services
{
    public interface IMoviesService
    {
         Task<List<Movie>> GetAllMoviesAsync();
         Task<Movie> GetMovieAsync(int id);
         Task<Movie> SaveMovieAsync(Movie movie);
         Task UpdateMovieAsync(int id, Movie movie);
         Task DeleteMovieAsync(Movie movie);
        Genre GetGenreById(byte genreId);
    }
}