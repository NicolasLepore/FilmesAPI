using FilmesAPI.Data.Dtos.SessaoDtos;
using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.FilmesDtos;

#nullable disable
public class ReadFilmeDtos
{
    // Classe Intermediaria dos dados
    public string Name { get; set; }
    public string Gender { get; set; }
    public int Duration { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}
