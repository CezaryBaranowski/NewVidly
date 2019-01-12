using AutoMapper;
using NewVidly2.Controllers.DTOs;
using NewVidly2.Core.Models;

namespace NewVidly.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, Movie>();
            //Domain to API Resource
            CreateMap<Movie, MovieDto>();
            CreateMap<Rental, RentalDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Rental, RentalDto>();
            CreateMap<MembershipType, MembershipTypeDto>();

            //API Resource to Domain
            CreateMap<MovieDto, Movie>();
            CreateMap<RentalDto, Rental>(MemberList.Source);
            CreateMap<CustomerDto, Customer>();
            CreateMap<RentalDto, Rental>();
            CreateMap<MembershipTypeDto, MembershipType>();



        }
    }
}