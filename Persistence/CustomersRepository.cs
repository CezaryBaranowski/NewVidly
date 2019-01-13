using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewVidly2.Core.Models;
using NewVidly2.Core.Repositories;

namespace NewVidly2.Persistence
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly VidlyDbContext _dbContext;
        private readonly IMapper _mapper;
        public CustomersRepository(VidlyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            return await _dbContext.Customers.Include(c=>c.MemebershipType).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _dbContext.Customers.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task AddCustomerAsync(Customer customer)
        {
           await _dbContext.Customers.AddAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customerToRemove =  await this.GetByIdAsync(id);
            _dbContext.Customers.Remove(customerToRemove);
        }
    }
}