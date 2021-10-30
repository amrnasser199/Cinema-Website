using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;
using Vidly.Models;
using Vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        private movieDB _DbContext;
        public MoviesController()
        {
            _DbContext = new movieDB();
        }
        protected override void Dispose(bool disposing)
        {
            _DbContext.Dispose();
        }
        public ViewResult Index()
        {
            //var movies = _DbContext.movies.Include(c => c.Genre).ToList();
            return View(/*movies*/);
        }
        public ActionResult New()
        {
            var vmodel = new NewMovieViewModel
            {
                genres = _DbContext.genres.ToList()
            };
            return View("New", vmodel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _DbContext.movies.SingleOrDefault(m => m.Id==id);
            if (movie == null)
                return HttpNotFound();
            var vmodel = new NewMovieViewModel(movie)
            { 
            genres=_DbContext.genres.ToList()

            };
            return View("New",vmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(Movie movie)
        {
            //var v_movie = m_view.movie;
            if (!ModelState.IsValid)
            {
                var viewmodel = new NewMovieViewModel(movie)
                {
                    //movie = v_movie,
                    genres = _DbContext.genres.ToList()
                };
                return View("New", viewmodel);
            }
            if (movie.Id == 0)
                {
                movie.DateAdded = DateTime.Now;
                _DbContext.movies.Add(movie);
                }
                else
            {
                var MovieInDb = _DbContext.movies.Single(m => m.Id==movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.NumberInStock = movie.NumberInStock;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
            }
                //try {
                    _DbContext.SaveChanges();
                //}
                //catch (Exception e)
                //{

                //    Console.WriteLine(e.Message);
                //}
                return RedirectToAction("Index", "Movies");
            }
            public ActionResult Details(int id)
            {
                var movies = _DbContext.movies.Include(b => b.Genre).SingleOrDefault(a => a.Id == id);
                if (movies == null)
                    return HttpNotFound();

                return View(movies);
            }
            // GET: Movies
            public ActionResult Random()
            {
                var movie = new Movie()
                {
                    Name = "SHREK!"
                };
                var customers = new List<Customer>
            {
                new Customer{Name="customer1" },
                new Customer{Name="customer2"}
            };
                var ViewModel = new RandomMovieViewModel
                {
                    Movie = movie,
                    Customers = customers
                };
                return View(ViewModel);
                // return Content("helloworld");
                // return HttpNotFound();
                //  return new EmptyResult();
                // return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });
            }


            //private IEnumerable<Movie> GetMovies()
            //{
            //    return new List<Movie>
            //    {
            //        new Movie { Id = 1, Name = "Shrek" },
            //        new Movie { Id = 2, Name = "Wall-e" }
            //    };
            // }


            //public ActionResult Edit(int id)
            //{
            //    return Content("id=" + id);
            //}
            //public ActionResult Index(int? PageIndex,string SortBy)
            //{
            //    if(!PageIndex.HasValue)
            //    {
            //        PageIndex = 1;
            //    }
            //    if(string.IsNullOrWhiteSpace(SortBy))
            //    {
            //        SortBy = "Name";
            //    }
            //    return Content(string.Format("PageIndex={0}&SortBy={1}", PageIndex, SortBy));
            //}
            //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]

            //public ActionResult ByReleasedDate(int Year,int month)
            //{
            //    return Content(Year + "/" + month);
            //}

        }
    }
