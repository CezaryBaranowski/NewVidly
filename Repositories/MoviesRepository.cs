using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewVidly.Models;
using NewVidly.Persistence;

namespace NewVidly.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {

        private readonly VidlyDbContext _dbContext;
        public MoviesRepository(VidlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Movie>> GetAllAsync()
        {
            return await _dbContext.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}