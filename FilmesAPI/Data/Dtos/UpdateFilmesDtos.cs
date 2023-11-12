using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace FilmesAPI.Data.Dtos;

#nullable disable
public class UpdateFilmeDtos
{
    // Classe Intermediaria dos dados

    [Required(ErrorMessage = "O nome do filme é um campo obrigatório")]
    [MinLength(3, ErrorMessage = "Este campo deve ser maior que 2 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O gênero do filme é um campo obrigatório")]
    [MinLength(3, ErrorMessage = "Este campo deve ser maior que 2 caracteres")]
    public string Gender { get; set; }

    [Range(70, 600, ErrorMessage = "A duração do filme deve ser de 70 à 600 minutos")]
    public int Duration { get; set; }
}
