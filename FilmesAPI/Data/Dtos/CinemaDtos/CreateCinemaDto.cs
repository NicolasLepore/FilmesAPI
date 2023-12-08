using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.CinemaDtos
{
    public class CreateCinemaDto
    { 
        [Required]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
    }
}
