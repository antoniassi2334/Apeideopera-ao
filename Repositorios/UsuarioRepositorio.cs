using Apeideoperaçao.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly VendasContext _context;

    public UsuarioRepositorio(VendasContext context)
    {
        _context = context;
    }

    public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<UsuarioModel> BuscarPorId(int id)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> Apagar(int id)
    {
        UsuarioModel usuario = await BuscarPorId(id);
        if (usuario == null) return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }
}
