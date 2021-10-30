using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Models;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private movieDB _Context;
        public NewRentalsController()
        {
            _Context = new movieDB();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals (RentalDto newRental)
        {
            // Defensive way

            //if (newRental.MovieIds.Count == 0)
            //    return BadRequest("No movie Ids have been given");
            var customer = _Context.customers.Single(c => c.Id == newRental.CustomerId);
            // Defensive way

            //if (customer == null)
            //    return BadRequest("CustomerId is not valid");
            var movies = _Context.movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            // Defensive way
            //if (movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("one or more movie ids are not valid");
            foreach (var movie in movies)
            {
                //optimistic and defensive way
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie Is Not Available");
                movie.NumberAvailable--;
                var rental= new Rental
                    {

                    movie=movie,
                    customer=customer,
                    DateRented=DateTime.Now
                    };
                _Context.Rentals.Add(rental);
            }
            _Context.SaveChanges();
            return Ok();
        }
    }
}
