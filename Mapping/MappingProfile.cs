using AutoMapper;
using NewVidly2.Models;
using NewVidly2.DTOs;

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

            //API Resource to Domain
            CreateMap<MovieDto, Movie>();
            CreateMap<RentalDto, Rental>(MemberList.Source);
            CreateMap<CustomerDto, Customer>();
            CreateMap<RentalDto, Rental>();
            CreateMap<MembershipTypeDto, MembershipType>();


            
        }    
    }
}