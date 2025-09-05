using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PedidosProdutosRepositorio : IPedidosProdutosRepositorio
{
    private readonly VendasContext _context;

    public PedidosProdutosRepositorio(VendasContext context)
    {
        _context = context;
    }

    public async Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos()
    {
        return await _context.PedidosProdutos.ToListAsync();
    }

    public async Task<PedidosProdutosModel> BuscarPorId(int id)
    {
        return await _context.PedidosProdutos.FirstOrDefaultAsync(pp => pp.Id == id);
    }

    public async Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidosProdutos)
    {
        _context.PedidosProdutos.Add(pedidosProdutos);
        await _context.SaveChangesAsync();
        return pedidosProdutos;
    }

    public async Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidosProdutos)
    {
        _context.PedidosProdutos.Update(pedidosProdutos);
        await _context.SaveChangesAsync();
        return pedidosProdutos;
    }

    public async Task<bool> Apagar(int id)
    {
        PedidosProdutosModel pedidosProdutos = await BuscarPorId(id);
        if (pedidosProdutos == null) return false;

        _context.PedidosProdutos.Remove(pedidosProdutos);
        await _context.SaveChangesAsync();
        return true;
    }
}
