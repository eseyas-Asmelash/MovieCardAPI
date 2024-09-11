using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieInfrustructure.Data;
using MovieShared.DTOs;
using MovieModels.Entities;
using MovieInfrustructure.Repository;

namespace MoviePresentation.Controllers
{/*
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieCardAPIContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MovieCardAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies(string search = "")
        {

            IQueryable<Movie> movies = _context.Movies
                                   .Include(m => m.Director)
                                   .ThenInclude(d => d.ContactInfo)
                                   .Include(m => m.Actors)
                                   .Include(m => m.Genres);


            if (!string.IsNullOrEmpty(search))
            {
                movies = movies.Where(m => m.Title.Contains(search) ||
                                         m.Genres.Any(g => g.Name == search) ||
                                         m.Director.Name.Contains(search) ||
                                         m.Actors.Any(g => g.Name == search));
            }

            var movieList = await movies.ToListAsync();

            var movieDtos = _mapper.Map<IEnumerable<MovieDto>>(movieList);

            return Ok(movieDtos);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _context.Movies
                                      .Include(m => m.Director)
                                      .ThenInclude(d => d.ContactInfo)
                                      .Include(m => m.Actors)
                                      .Include(m => m.Genres)
                                      .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var movieDto = _mapper.Map<MovieDto>(movie);
            return Ok(movieDto);
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovie(CreateMovieDto createMovieDto)
        {
            var movie = _mapper.Map<Movie>(createMovieDto);

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            var movieDto = _mapper.Map<MovieDto>(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movieDto.Id }, movieDto);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, UpdateMovieDto updateMovieDto)
        {
            var movie = await _context.Movies
                                      .Include(m => m.Director)
                                      .Include(m => m.Actors)
                                      .Include(m => m.Genres)
                                      .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            _mapper.Map(updateMovieDto, movie);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }*/
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository<Movie> _movieRepository;

        public MoviesController(IMovieRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _movieRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            await _movieRepository.AddAsync(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            await _movieRepository.UpdateAsync(movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var success = await _movieRepository.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}


