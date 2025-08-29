public class UsuarioModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateOnly DataNascimento { get; set; }

    // Relacionamento 1:N com Pedido
    public ICollection<PedidoModel> Pedidos { get; set; }
}