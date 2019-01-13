using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NewVidly2.Controllers.DTOs;
using NewVidly2.Core;
using NewVidly2.Core.Models;
using NewVidly2.Core.Repositories;

namespace NewVidly2.Services
{
    public class CustomersService : ICustomersService
    {
        ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CustomersService(ICustomersRepository customersRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customersRepository.GetAllAsync();
            var result = _mapper.Map<List<Customer>, List<CustomerDto>>(customers);
            return result;
        }

        public async Task<CustomerDto> GetCustomerAsync(int id)
        {
            var customer = await _customersRepository.GetByIdAsync(id);
            var result = _mapper.Map<Customer, CustomerDto>(customer);
            return result;
        }

        public async Task<CustomerDto> SaveCustomerAsync(CustomerDto customerDto)
        {
            var newCustomer = _mapper.Map<CustomerDto, Customer>(customerDto);
            await _customersRepository.AddCustomerAsync(newCustomer);
            await _unitOfWork.CompleteAsync();

            var savedCustomer = await _customersRepository.GetByIdAsync(newCustomer.Id);
            var result = _mapper.Map<Customer,CustomerDto>(savedCustomer);
            return result;
        }

        public async Task<CustomerDto> UpdateCustomerAsync(int id, CustomerDto customerDto)
        {
            var customerToUpdate = await _customersRepository.GetByIdAsync(id);

            _mapper.Map(customerDto, customerToUpdate);
            await _unitOfWork.CompleteAsync();

            var updatedCustomer = await _customersRepository.GetByIdAsync(customerToUpdate.Id);
            var result = _mapper.Map<Customer, CustomerDto>(updatedCustomer);
            return result;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customersRepository.DeleteCustomerAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}