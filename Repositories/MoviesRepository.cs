using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewVidly2.Models;
using NewVidly2.Persistence;

namespace NewVidly2.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {

        private readonly VidlyDbContext _dbContext;
        private readonly IMapper _mapper;
        public MoviesRepository(VidlyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Movie> SaveMovieAsync(Movie movie)
        {
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _dbContext.Movies.Include(m=>m.Genre).ToListAsync();
        }
        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movies.Include(m=>m.Genre).SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateMovieAsync(int id, Movie movie)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(Movie movie)
        {
            _dbContext.Movies.Remove(movie);

            await _dbContext.SaveChangesAsync();
        }

        public Genre GetGenreById(byte genreId)
        {
            return _dbContext.Genres.Where(g => g.Id == genreId).FirstOrDefault();
        }
    }
}