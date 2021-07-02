using CasaNova.Dominio.Entidades;
using CasaNova.Infra.Maps;
using Microsoft.EntityFrameworkCore;

namespace CasaNova.Infra.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Imovel> Imoveis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImovelMap());
        }
    }
}
