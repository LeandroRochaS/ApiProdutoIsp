using Microsoft.AspNetCore.Mvc;
using ProdutoExempoApiSolid.Model;
using ProdutoExempoApiSolid.Repository.IRepository;


namespace  ProdutoExempoApiSolid.Controller;

[Route("api/produtos")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }


    [HttpGet()]
    public IActionResult GetAll()
    {
        var produtos = _produtoRepository.GetAll();

        return Ok(produtos);
    }


    // GET: api/Produto?nome=NomeProduto
    [HttpGet("por-nome")]
    public IActionResult Get([FromQuery] string nome)
    {
        var produtos = _produtoRepository.BuscarPorNome(nome); 

        return Ok(produtos);
    }

    // GET: api/Produto/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var produto = _produtoRepository.GetById(id);

        if (produto == null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    // POST: api/Produto
    [HttpPost]
    public IActionResult Post([FromBody] ProdutoModel produto)
    {
        _produtoRepository.Inserir(produto);

        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    // PUT: api/Produto/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProdutoModel produto)
    {
        var produtoExistente = _produtoRepository.GetById(id);

        if (produtoExistente == null)
        {
            return NotFound();
        }

        _produtoRepository.Atualizar(produto);

        return NoContent();
    }

    // DELETE: api/Produto/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produtoExistente = _produtoRepository.GetById(id);

        if (produtoExistente == null)
        {
            return NotFound();
        }

        _produtoRepository.Excluir(id);

        return NoContent();
    }
}
