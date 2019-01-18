using System.Collections.Generic;
using System.Threading.Tasks;
using NewVidly2.Core.Models;

namespace NewVidly2.Core.Repositories
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> GetByEmailAsync(string email);
        Task AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}