using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewVidly2.Controllers.DTOs;
using NewVidly2.Core;
using NewVidly2.Core.Models;
using NewVidly2.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewVidly2.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMoviesService _moviesService;
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IMoviesService moviesService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _moviesService = moviesService;
        }

        [HttpGet("/api/movies")]
        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            var movies = await _moviesService.GetAllMoviesAsync();
            return movies;
        }

        [HttpGet("/api/movies/{id}")]
        public async Task<MovieDto> GetMovie(int id)
        {
            var movie = await _moviesService.GetMovieAsync(id);
            return movie;
        }

        [HttpPost("/api/movies")]
        public async Task<IActionResult> CreateMovie([FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _moviesService.SaveMovieAsync(movieDto);
            return Ok(result);
        }

        [HttpPut("/api/movies/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movieToUpdate = await _moviesService.GetMovieAsync(id);
            if (movieToUpdate == null)
                return NotFound();

            await _moviesService.UpdateMovieAsync(id, movieDto);
        
            var result = _moviesService.GetMovieAsync(id);
            return Ok(result);
        }

        [HttpDelete("/api/movies/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movieToDelete = await _moviesService.GetMovieAsync(id);
            if (movieToDelete == null)
                return NotFound();

            await _moviesService.DeleteMovieAsync(movieToDelete.Id);
            return Ok(id);
        }

    }
}