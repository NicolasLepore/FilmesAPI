using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.CinemaDtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable 1591

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCinemaById), new { id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> GetCinema([FromQuery]int skip = 0, [FromQuery]int take = 20)
        {
            var cinemas = _context.Cinemas.Skip(skip).Take(take).ToList();
            var cinemasDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);
            return cinemasDto;
        }

        [HttpGet("{id}")]
        public IActionResult GetCinemaById(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema == null) return NotFound();
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema == null) return NotFound();
            var mappedCinema = _mapper.Map<Cinema>(cinemaDto);
            _mapper.Map(mappedCinema, cinema);
            _context.SaveChanges();
            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema == null) return NotFound();
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
