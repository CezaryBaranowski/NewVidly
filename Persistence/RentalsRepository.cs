using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewVidly2.Core.Models;
using NewVidly2.Core.Repositories;

namespace NewVidly2.Persistence
{
    public class RentalsRepository : IRentalsRepository
    {
         private readonly VidlyDbContext _dbContext;
        private readonly IMapper _mapper;
        public RentalsRepository(VidlyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Rental>> GetAllAsync()
        {
            return await _dbContext.Rentals.Include(r => r.Customer).Include(r => r.Movie).ToListAsync();
        }
        public async Task<Rental> GetByIdAsync(int id)
        {
            return await _dbContext.Rentals.Include(r => r.Customer).Include(r => r.Movie).SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRentalAsync(Rental rental)
        {
            await _dbContext.Rentals.AddAsync(rental);
        }

        public async Task DeleteRentalAsync(int id)
        {     
            var rentalToRemove = await this.GetByIdAsync(id);
              _dbContext.Rentals.Remove(rentalToRemove);
              
        }
    }
}