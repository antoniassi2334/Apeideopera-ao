using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoriaRepositorio : ICategoriaRepositorio
{
    private readonly VendasContext _context;

    public CategoriaRepositorio(VendasContext context)
    {
        _context = context;
    }

    public async Task<List<CategoriaModel>> BuscarTodasCategorias()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<CategoriaModel> BuscarPorId(int id)
    {
        return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CategoriaModel> Adicionar(CategoriaModel categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<CategoriaModel> Atualizar(CategoriaModel categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<bool> Apagar(int id)
    {
        CategoriaModel categoria = await BuscarPorId(id);
        if (categoria == null) return false;

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
        return true;
    }
}
