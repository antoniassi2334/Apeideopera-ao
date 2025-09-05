using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SistemaProduto.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> Get()
        {
            return Ok(await _produtoRepositorio.BuscarTodosProdutos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetById(int id)
        {
            var produto = await _produtoRepositorio.BuscarPorId(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Post(ProdutoModel produto)
        {
            var novoProduto = await _produtoRepositorio.Adicionar(produto);
            return CreatedAtAction(nameof(GetById), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Put(int id, ProdutoModel produto)
        {
            if (id != produto.Id) return BadRequest();
            var atualizado = await _produtoRepositorio.Atualizar(produto);
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var apagado = await _produtoRepositorio.Apagar(id);
            if (!apagado) return NotFound();
            return NoContent();
        }
    }
}