using System.Collections.Generic;
using System.Threading.Tasks;
using NewVidly2.Core.Models;

namespace NewVidly2.Core.Repositories
{
    public interface IRentalsRepository
    {
        Task<List<Rental>> GetAllAsync();
        Task<Rental> GetByIdAsync(int id);
        Task AddRentalAsync(Rental movie);
        Task DeleteRentalAsync(int id);
    }
}