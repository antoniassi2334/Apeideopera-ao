using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PedidosProdutosModelMap : IEntityTypeConfiguration<PedidosProdutosModel>
{
    public void Configure(EntityTypeBuilder<PedidosProdutosModel> builder)
    {
        builder.ToTable("PedidosProdutos");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Quantidade)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.PrecoUnitario)
            .IsRequired();
    }
}