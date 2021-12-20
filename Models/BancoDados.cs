using Microsoft.EntityFrameworkCore;

namespace DiogoTurismo.Models
{
    public class BancoDados : DbContext
    {
        public BancoDados(DbContextOptions<BancoDados> options) : base(options) { }


        public DbSet<Cadastro> Cadastro { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<Passagem> Passagens { get; set; }
    }
}
