using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using FilmesAPI.Data.Dtos.FilmesDtos;

namespace FilmesAPI.Controllers;
#pragma warning disable 1591

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _dbContext;
    private IMapper _mapper;

    // Dependency Injection
    public FilmeController(FilmeContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">
    /// Objeto com os campos necessários para criação de um filme
    /// </param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddFilme([FromBody]CreateFilmeDtos filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _dbContext.Filmes.Add(filme);
        _dbContext.SaveChanges();
        return CreatedAtAction
            (nameof(GetFilmeID), new { id = filme.Id }, filme); //201
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDtos> GetFilme([FromQuery] int skip = 0,
        [FromQuery] int take = 20,
        [FromQuery] string? cinema = null)
    {
        if(cinema == null)
        {
            return _mapper.Map<List<ReadFilmeDtos>>
            (_dbContext.Filmes.Skip(skip).Take(take).ToList());
        }

        return _mapper.Map<List<ReadFilmeDtos>>(_dbContext.Filmes
            .Skip(skip).Take(take)
            .Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.Nome == cinema))
            .ToList());
        
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmeID(int id)
    {
        var filme = _dbContext.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound(); //404
        var filmeDto = _mapper.Map<ReadFilmeDtos>(filme);
        return Ok(filmeDto); //200
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilme(int id,[FromBody]UpdateFilmeDtos filmeDto)
    {
        var filme = _dbContext.Filmes.FirstOrDefault(filme => 
        filme.Id == id);
        if(filme == null) return NotFound();
        else
        {
            _mapper.Map(filmeDto, filme);
            _dbContext.SaveChanges();
            return NoContent(); //204
        }
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateFilmeParcial(int id,
        [FromBody]JsonPatchDocument<UpdateFilmeDtos>patch)
    {
        var filme = _dbContext.Filmes.FirstOrDefault(f => 
        f.Id == id);
        if(filme == null) return NotFound();

        var filmeDto = _mapper.Map<UpdateFilmeDtos>(filme);
        patch.ApplyTo(filmeDto, ModelState);
        if(!TryValidateModel(filmeDto))
        {
            return ValidationProblem(ModelState); // Resulta num BadRequest (400)
        }
        _mapper.Map(filmeDto, filme);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilmes(int id)
    {
        var filme = _dbContext.Filmes.FirstOrDefault(f => f.Id == id);
        if(filme == null) return NotFound();
        _dbContext.Remove(filme);
        _dbContext.SaveChanges();
        return NoContent();
    }
}
