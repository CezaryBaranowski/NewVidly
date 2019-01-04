using System.Collections.Generic;
using System.Threading.Tasks;
using NewVidly.Models;

namespace NewVidly.Services
{
    public interface IMoviesService
    {
         Task<List<Movie>> GetAllMoviesAsync();

         Task<Movie> GetMovieAsync(int id);
    }
}