using ConsumerApiC_.Services;
using Microsoft.AspNetCore.Mvc;
using moviesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsumerApiC_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        // Retrieve all movies
        [HttpGet]
        public async Task<List<Movie>> GetMovies()
        {
            return await _movieService.AllTheMovies();
        }

        // Add a new movie
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie newMovie)
        {
            var movie = await _movieService.AddMovieAsync(newMovie);
            return CreatedAtAction(nameof(GetMovies), new { id = movie.MovieId }, movie);
        }

        // Update an existing movie
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            if (id != updatedMovie.MovieId)
            {
                return BadRequest();
            }

            var movie = await _movieService.UpdateMovieAsync(updatedMovie);
            return Ok(movie);
        }

        [HttpDelete("{\id}", Name = "DeleteMovie")]
        public async Task<IActionResult> DeleteMovie(int id)
        { 
            await _movieService.DeleteMovieAsync(id);

            return NoContent();
        }
    }
}
