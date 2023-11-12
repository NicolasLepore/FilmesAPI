using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

#nullable disable
public class ReadFilmeDtos
{
    // Classe Intermediaria dos dados
    public string Name { get; set; }
    public string Gender { get; set; }
    public int Duration { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;

}
