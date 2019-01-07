using AutoMapper;
using NewVidly.DTOs;
using NewVidly.Models;

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


            
        }    
    }
}