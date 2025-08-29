using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICategoriaRepositorio
{
    Task<List<CategoriaModel>> BuscarTodasCategorias();
    Task<CategoriaModel> BuscarPorId(int id);
    Task<CategoriaModel> Adicionar(CategoriaModel categoria);
    Task<CategoriaModel> Atualizar(CategoriaModel categoria);
    Task<bool> Apagar(int id);
}