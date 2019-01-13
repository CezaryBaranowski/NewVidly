using NewVidly2.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewVidly2.Core.Repositories
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task AddMovieAsync(Movie movie);
        Task DeleteMovieAsync(int id);
        Genre GetGenreById(byte genreId);
    }
}