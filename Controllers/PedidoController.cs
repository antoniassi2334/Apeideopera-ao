using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoRepositorio _pedidoRepositorio;

    public PedidoController(IPedidoRepositorio pedidoRepositorio)
    {
        _pedidoRepositorio = pedidoRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<PedidoModel>>> Get()
    {
        return Ok(await _pedidoRepositorio.BuscarTodosPedidos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PedidoModel>> GetById(int id)
    {
        var pedido = await _pedidoRepositorio.BuscarPorId(id);
        if (pedido == null) return NotFound();
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<ActionResult<PedidoModel>> Post(PedidoModel pedido)
    {
        var novoPedido = await _pedidoRepositorio.Adicionar(pedido);
        return CreatedAtAction(nameof(GetById), new { id = novoPedido.Id }, novoPedido);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PedidoModel>> Put(int id, PedidoModel pedido)
    {
        if (id != pedido.Id) return BadRequest();
        var atualizado = await _pedidoRepositorio.Atualizar(pedido);
        return Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var apagado = await _pedidoRepositorio.Apagar(id);
        if (!apagado) return NotFound();
        return NoContent();
    }
}
