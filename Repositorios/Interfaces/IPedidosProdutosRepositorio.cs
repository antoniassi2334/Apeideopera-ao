using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPedidosProdutosRepositorio
{
    Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos();
    Task<PedidosProdutosModel> BuscarPorId(int id);
    Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidosProdutos);
    Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidosProdutos);
    Task<bool> Apagar(int id);
}