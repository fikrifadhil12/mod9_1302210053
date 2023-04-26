using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using MODUL9_1302210053;



namespace MODUL9_1302210053.Controllers
{
    [ApiController]
    [Route("Api/MOVIES[controller]")]
    public class MovieController : ControllerBase
    {
        private static readonly List<Movie> _movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Stars = new List<string>{"Tim Robbins", "Morgan Freeman"},
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."
            },
            new Movie
            {
                Id = 2,
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Stars = new List<string>{"Marlon Brando", "Al Pacino", "James Caan"},
                Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
            },
            new Movie
            {
                Id = 3,
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Stars = new List<string>{"Christian Bale", "Heath Ledger", "Aaron Eckhart"},
                Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."
            }
        };

        [HttpGet]
        public IEnumerable<Movie> GetMovie()
        {
            return _movies;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            movie.Id = _movies.Max(m => m.Id) + 1;
            _movies.Add(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _movies.Remove(movie);
            return NoContent();
        }
    }
}
