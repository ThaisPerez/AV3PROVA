using CasaNova.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaNova.Infra.Maps
{
    public class ImovelMap : IEntityTypeConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            builder.ToTable("Imoveis");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.QtdQuartos).IsRequired().HasMaxLength(6).HasColumnType("varchar(6)");
            builder.Property(x => x.Valor).IsRequired().HasMaxLength(10).HasColumnType("varchar(10)");
        }
    }
}
