using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoriaModelMap : IEntityTypeConfiguration<CategoriaModel>
{
    public void Configure(EntityTypeBuilder<CategoriaModel> builder)
    {
        builder.ToTable("Categorias");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Status)
            .IsRequired()
            .HasMaxLength(20);
    }
}