using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PedidosProdutosController : ControllerBase
{
    private readonly IPedidosProdutosRepositorio _pedidosProdutosRepositorio;

    public PedidosProdutosController(IPedidosProdutosRepositorio pedidosProdutosRepositorio)
    {
        _pedidosProdutosRepositorio = pedidosProdutosRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<PedidosProdutosModel>>> Get()
    {
        return Ok(await _pedidosProdutosRepositorio.BuscarTodosPedidosProdutos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PedidosProdutosModel>> GetById(int id)
    {
        var item = await _pedidosProdutosRepositorio.BuscarPorId(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<PedidosProdutosModel>> Post(PedidosProdutosModel pedidosProdutos)
    {
        var novoItem = await _pedidosProdutosRepositorio.Adicionar(pedidosProdutos);
        return CreatedAtAction(nameof(GetById), new { id = novoItem.Id }, novoItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PedidosProdutosModel>> Put(int id, PedidosProdutosModel pedidosProdutos)
    {
        if (id != pedidosProdutos.Id) return BadRequest();
        var atualizado = await _pedidosProdutosRepositorio.Atualizar(pedidosProdutos);
        return Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var apagado = await _pedidosProdutosRepositorio.Apagar(id);
        if (!apagado) return NotFound();
        return NoContent();
    }
}