public class PedidoModel
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public UsuarioModel Usuario { get; set; }

    public string EnderecoEntrega { get; set; }
    public string Status { get; set; } // Pendente, Processando, Enviado, Entregue
    public string MetodoPagamento { get; set; }

    // Relacionamento N:N com Produto via PedidosProdutos
    public ICollection<PedidosProdutosModel> PedidosProdutos { get; set; }
}