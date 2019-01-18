using System.Collections.Generic;
using System.Threading.Tasks;
using NewVidly2.Controllers.DTOs;

namespace NewVidly2.Services
{
    public interface ICustomersService
    {
        Task<List<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerAsync(int id);
        Task<CustomerDto> GetCustomerByEmailAsync(string email);        
        Task<CustomerDto> SaveCustomerAsync(CustomerDto customerDto);
        Task<CustomerDto> UpdateCustomerAsync(int id, CustomerDto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}