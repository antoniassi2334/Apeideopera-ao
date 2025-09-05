using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly VendasContext _context;

    public ProdutoRepositorio(VendasContext context)
    {
        _context = context;
    }

    public async Task<List<ProdutoModel>> BuscarTodosProdutos()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<ProdutoModel> BuscarPorId(int id)
    {
        return await _context.Produtos.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<ProdutoModel> Atualizar(ProdutoModel produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<bool> Apagar(int id)
    {
        ProdutoModel produto = await BuscarPorId(id);
        if (produto == null) return false;

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return true;
    }
}
