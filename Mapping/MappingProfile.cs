using AutoMapper;
using NewVidly.DTOs;
using NewVidly.Models;

namespace NewVidly.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>();
        }    
    }
}