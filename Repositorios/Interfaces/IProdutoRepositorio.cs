using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProdutoRepositorio
{
    Task<List<ProdutoModel>> BuscarTodosProdutos();
    Task<ProdutoModel> BuscarPorId(int id);
    Task<ProdutoModel> Adicionar(ProdutoModel produto);
    Task<ProdutoModel> Atualizar(ProdutoModel produto);
    Task<bool> Apagar(int id);
}