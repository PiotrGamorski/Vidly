using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DtosModels;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.ApiControllers
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // /api/movies (GET)
        [HttpGet]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public IEnumerable<MovieDto> GetMovie(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        // /api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }

        // /api/movies (POST) -> Create -> New()
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieToDb = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movieToDb);
            _context.SaveChanges();

            movieDto.Id = movieToDb.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieToDb.Id), movieDto);
        }

        // /api/movies (PUT) -> Edit
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(MovieDto movieDto, int id)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies
                .ToList()
                .SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);       // maps the values from movieDto to monieInDb !
            _context.SaveChanges();

            return Ok();
        }

        // /api/movies (DELETE)
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult Delete(int id)
        {
            var movieInDb = _context.Movies.ToList().SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
