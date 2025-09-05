using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PedidoRepositorio : IPedidoRepositorio
{
    private readonly VendasContext _context;

    public PedidoRepositorio(VendasContext context)
    {
        _context = context;
    }

    public async Task<List<PedidoModel>> BuscarTodosPedidos()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<PedidoModel> BuscarPorId(int id)
    {
        return await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<PedidoModel> Adicionar(PedidoModel pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<PedidoModel> Atualizar(PedidoModel pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<bool> Apagar(int id)
    {
        PedidoModel pedido = await BuscarPorId(id);
        if (pedido == null) return false;

        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
        return true;
    }
}
