using Microsoft.EntityFrameworkCore;

public class VendasContext : DbContext
{
    public VendasContext(DbContextOptions<VendasContext> options) : base(options) { }

    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<PedidoModel> Pedidos { get; set; }
    public DbSet<CategoriaModel> Categorias { get; set; }
    public DbSet<ProdutoModel> Produtos { get; set; }
    public DbSet<PedidosProdutosModel> PedidosProdutos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica os Maps
        modelBuilder.ApplyConfiguration(new UsuarioModelMap());
        modelBuilder.ApplyConfiguration(new CategoriaModelMap());
        modelBuilder.ApplyConfiguration(new ProdutoModelMap());
        modelBuilder.ApplyConfiguration(new PedidoModelMap());
        modelBuilder.ApplyConfiguration(new PedidosProdutosModelMap());

        base.OnModelCreating(modelBuilder);
    }
}