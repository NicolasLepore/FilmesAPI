using Microsoft.EntityFrameworkCore;
using FilmesAPI.Models;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Filme> Filmes { get; set; }
    }
}
