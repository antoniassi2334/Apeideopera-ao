using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPedidoRepositorio
{
    Task<List<PedidoModel>> BuscarTodosPedidos();
    Task<PedidoModel> BuscarPorId(int id);
    Task<PedidoModel> Adicionar(PedidoModel pedido);
    Task<PedidoModel> Atualizar(PedidoModel pedido);
    Task<bool> Apagar(int id);
}