using System.Collections.Generic;
using System.Threading.Tasks;
using NewVidly2.Controllers.DTOs;

namespace NewVidly2.Services
{
    public interface IRentalsService
    {
        Task<List<RentalDto>> GetAllRentalsAsync();
        Task<RentalDto> GetRentalAsync(int id);
        Task<RentalDto> SaveRentalAsync(RentalDto rental);
        Task UpdateRentalAsync(int id, RentalDto rental);
    }
}