using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DtosModels;
using Vidly.Models;

namespace Vidly.Controllers.ApiControllers
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController() {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");

            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Invalid customer ID.");

            //takes those movies which have common Id with the newRental list of ids.
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MoviesIds are invalid.");

            foreach (var movie in movies) 
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");
                movie.NumberAvailable--;

                var _Rental = new _Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context._Rentals.Add(_Rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
