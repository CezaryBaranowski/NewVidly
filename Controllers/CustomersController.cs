using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewVidly2.Controllers.DTOs;
using NewVidly2.Core;
using NewVidly2.Services;

namespace NewVidly2.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _customersService;
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(ICustomersService customersService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _customersService = customersService;
        }

        [HttpGet("/api/customers")]
       // [Authorize]
        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customers = await _customersService.GetAllCustomersAsync();
            return customers;
        }

        [HttpGet("/api/customers/{id}")]
        public async Task<CustomerDto> GetCustomer(int id)
        {
            var customer = await _customersService.GetCustomerAsync(id);
            return customer;
        }

        [HttpPost("/api/customers")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _customersService.SaveCustomerAsync(customerDto);
            return Ok(result);
        }

        [HttpPut("/api/customers/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerToUpdate = await _customersService.GetCustomerAsync(id);
            if (customerToUpdate == null)
                return NotFound();

            var result = await _customersService.UpdateCustomerAsync(id, customerDto);
            return Ok(result);
        }

        [HttpDelete("/api/customers/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customerToDelete = await _customersService.GetCustomerAsync(id);
            if (customerToDelete == null)
                return NotFound();

            await _customersService.DeleteCustomerAsync(customerToDelete.Id);
            return Ok(id);
        }
    }
}