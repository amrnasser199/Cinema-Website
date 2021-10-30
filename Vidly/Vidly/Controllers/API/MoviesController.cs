using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Models;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;
namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private movieDB _context;
        private IMapper _mapper;
        public MoviesController(IMapper mapper)
        {
            _mapper = mapper;
            _context = new movieDB();
        }
        // GET/api/movies
        public IHttpActionResult GetMovies(string query=null)
        {
            var MovieQuery = _context.movies.Include(c => c.Genre).Where(c=>c.NumberAvailable>0);
            if (!string.IsNullOrWhiteSpace(query))
                MovieQuery = MovieQuery.Where(m => m.Name.Contains(query));
           var MovieDto=MovieQuery.ToList().Select(_mapper.Map<Movie, MovieDto>);
            return Ok(MovieDto);
        }
        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.movies.SingleOrDefault(m => m.Id == id);
            if(movie==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Movie,MovieDto>(movie));
        }
        // POST /api/movies
        [HttpPost]
        public IHttpActionResult Createmovie(MovieDto movieDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        // put /api/movies/1

        [HttpPut]
        public IHttpActionResult Updatemovie (int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = _context.movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _mapper.Map< MovieDto,Movie>( movieDto, movie);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Deletemovie(int id)
        {
            var movie = _context.movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.movies.Remove(movie);
            _context.SaveChanges();
            return Ok();

        }




    }
}
