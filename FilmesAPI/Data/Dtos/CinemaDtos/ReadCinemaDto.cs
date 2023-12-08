using FilmesAPI.Data.Dtos.EnderecoDtos;
using FilmesAPI.Data.Dtos.SessaoDtos;

namespace FilmesAPI.Data.Dtos.CinemaDtos
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
        public ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}
