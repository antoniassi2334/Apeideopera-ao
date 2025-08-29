using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProdutoModelMap : IEntityTypeConfiguration<ProdutoModel>
{
    public void Configure(EntityTypeBuilder<ProdutoModel> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Descricao)
            .HasMaxLength(500);

        builder.Property(p => p.PrecoUnitario)
            .IsRequired()
            .HasColumnType("decimal(18,2)");


        // Relacionamento N:N com Pedidos via PedidosProdutos
        builder.HasMany(p => p.PedidosProdutos)
               .WithOne(pp => pp.Produto)
               .HasForeignKey(pp => pp.ProdutoId);
    }
}