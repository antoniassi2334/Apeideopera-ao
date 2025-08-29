using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepositorio _categoriaRepositorio;

    public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
    {
        _categoriaRepositorio = categoriaRepositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoriaModel>>> Get()
    {
        return Ok(await _categoriaRepositorio.BuscarTodasCategorias());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaModel>> GetById(int id)
    {
        var categoria = await _categoriaRepositorio.BuscarPorId(id);
        if (categoria == null) return NotFound();
        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaModel>> Post(CategoriaModel categoria)
    {
        var novaCategoria = await _categoriaRepositorio.Adicionar(categoria);
        return CreatedAtAction(nameof(GetById), new { id = novaCategoria.Id }, novaCategoria);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoriaModel>> Put(int id, CategoriaModel categoria)
    {
        if (id != categoria.Id) return BadRequest();
        var atualizado = await _categoriaRepositorio.Atualizar(categoria);
        return Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var apagado = await _categoriaRepositorio.Apagar(id);
        if (!apagado) return NotFound();
        return NoContent();
    }
}