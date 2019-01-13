using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewVidly2.Controllers.DTOs;
using NewVidly2.Core;
using NewVidly2.Services;

namespace NewVidly2.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalsService _rentalsService;
        private readonly IUnitOfWork _unitOfWork;

        public RentalsController(IRentalsService rentalsService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _rentalsService = rentalsService;
        }

        [HttpGet("/api/rentals")]
        public async Task<IEnumerable<RentalDto>> GetRentals()
        {
            var rentals = await _rentalsService.GetAllRentalsAsync();
            return rentals;
        }

        [HttpGet("/api/rentals/{id}")]
        public async Task<RentalDto> GetRental(int id)
        {
            var rental = await _rentalsService.GetRentalAsync(id);
            return rental;
        }

        [HttpPost("/api/rentals")]
        public async Task<IActionResult> CreateRental([FromBody] RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _rentalsService.SaveRentalAsync(rentalDto);
            return Ok(result);
        }

        [HttpPut("/api/rentals/{id}")]
        public async Task<IActionResult> UpdateRental(int id, [FromBody] RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rentalToUpdate = await _rentalsService.GetRentalAsync(id);
            if (rentalToUpdate == null)
                return NotFound();

            await _rentalsService.UpdateRentalAsync(id, rentalDto);
        
            var result = _rentalsService.GetRentalAsync(id);
            return Ok(result);
        }
    }
}