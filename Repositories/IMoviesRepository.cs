using System.Collections.Generic;
using System.Threading.Tasks;
using NewVidly.Models;

namespace NewVidly.Repositories
{
    public interface IMoviesRepository
    {
         Task<List<Movie>> GetAllAsync();
         Task<Movie> GetByIdAsync(int id);
         Task<Movie> SaveMovieAsync(Movie movie);
         Task UpdateMovieAsync(int id, Movie movie);
         Task DeleteMovieAsync(Movie movie);
        Genre GetGenreById(byte genreId);
    }
}