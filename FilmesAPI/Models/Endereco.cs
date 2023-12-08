using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable 1591
#nullable disable
namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
