using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.CinemaDtos
{
    public class UpdateCinemaDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
