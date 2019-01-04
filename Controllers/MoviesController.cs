using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewVidly.DTOs;
using NewVidly.Models;
using NewVidly.Services;

namespace NewVidly.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;

        public MoviesController(IMoviesService moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }
        [HttpGet("api/movies")]
        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            var movies = await _moviesService.GetAllMoviesAsync();

            var result = _mapper.Map<List<Movie>, List<MovieDto>>(movies);

            return result;
        }

        [HttpGet("api/movies/{id}")]
        public async Task<MovieDto> GetMovie(int id)
        {
            var movie = await _moviesService.GetMovieAsync(id);

            var result = _mapper.Map<Movie,MovieDto>(movie);
            return result;
        }
    }
}