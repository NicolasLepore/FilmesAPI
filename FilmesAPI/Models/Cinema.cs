using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable 1591
#nullable disable
namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        // Com os LazyLoadingProxies, quando um cinema for criado, a instancia de endereço será
        // carregada nessa sua propriedade.

        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
