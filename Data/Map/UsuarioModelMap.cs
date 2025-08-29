using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsuarioModelMap : IEntityTypeConfiguration<UsuarioModel>
{
    public void Configure(EntityTypeBuilder<UsuarioModel> builder)
    {
        // Tabela
        builder.ToTable("Usuarios");

        // Chave primária
        builder.HasKey(u => u.Id);

        // Propriedades
        builder.Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.DataNascimento)
            .IsRequired();

        // Relacionamento 1:N com Pedido
        builder.HasMany(u => u.Pedidos)
               .WithOne(p => p.Usuario)
               .HasForeignKey(p => p.UsuarioId);
    }
}