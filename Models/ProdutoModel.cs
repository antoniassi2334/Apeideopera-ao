public class ProdutoModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal PrecoUnitario { get; set; }

    // Relacionamento N:N com Pedido via PedidosProdutos
    public ICollection<PedidosProdutosModel> PedidosProdutos { get; set; }
}