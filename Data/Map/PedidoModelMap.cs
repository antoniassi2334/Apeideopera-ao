using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PedidoModelMap : IEntityTypeConfiguration<PedidoModel>
{
    public void Configure(EntityTypeBuilder<PedidoModel> builder)
    {
        builder.ToTable("Pedidos");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.EnderecoEntrega)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Status)
            .IsRequired()
            .HasMaxLength(20);
    }
}