using LLA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLA.Infra.Data.EntitiesConfiguration;

public class ProjectConfiguration : IEntityTypeConfiguration<Projeto>
{
    public void Configure(EntityTypeBuilder<Projeto> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Titulo).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();

    }
}
