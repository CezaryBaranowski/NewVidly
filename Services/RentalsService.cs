using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NewVidly2.Controllers.DTOs;
using NewVidly2.Core;
using NewVidly2.Core.Models;
using NewVidly2.Core.Repositories;

namespace NewVidly2.Services
{
    public class RentalsService : IRentalsService
    {
        IRentalsRepository _rentalsRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public RentalsService(IRentalsRepository rentalsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _rentalsRepository = rentalsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RentalDto>> GetAllRentalsAsync()
        {
            var rentals = await _rentalsRepository.GetAllAsync();
            var result = _mapper.Map<List<Rental>, List<RentalDto>>(rentals);
            return result;
        }
        public async Task<RentalDto> GetMovieAsync(int id)
        {
            var rental = await _rentalsRepository.GetByIdAsync(id);
            var result = _mapper.Map<Rental, RentalDto>(rental);
            return result;
        }

        public async Task<RentalDto> SaveRentalAsync(RentalDto rental)
        {
            var newRental = _mapper.Map<RentalDto, Rental>(rental);
            newRental.DateRented = DateTime.Now;
            await _rentalsRepository.AddRentalAsync(newRental);
            await _unitOfWork.CompleteAsync();

            var savedRental = await _rentalsRepository.GetByIdAsync(newRental.Id);
            var result = _mapper.Map<Rental,RentalDto>(savedRental);
            return result;
        }

        public async Task UpdateRentalAsync(int id, RentalDto rentalDto)
        {
             var rentalToUpdate = await _rentalsRepository.GetByIdAsync(id);

            _mapper.Map(rentalDto, rentalToUpdate);
            rentalToUpdate.DateReturned = DateTime.Now;
            await _unitOfWork.CompleteAsync();

            var updatedRental = await _rentalsRepository.GetByIdAsync(rentalToUpdate.Id);
            var result = _mapper.Map<Rental, RentalDto>(updatedRental);
        }
    }
}