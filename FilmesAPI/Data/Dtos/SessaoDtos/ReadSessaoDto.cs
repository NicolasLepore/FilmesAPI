using FilmesAPI.Data.Dtos.CinemaDtos;
using FilmesAPI.Data.Dtos.FilmesDtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.SessaoDtos
{
    public class ReadSessaoDto
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
    }
}
