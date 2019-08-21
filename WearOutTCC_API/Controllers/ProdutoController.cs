using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WearOutTCC_API.Models;
using WearOutTCC_API.Models.ModelContext;

namespace WearOutTCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoContext _context;

        public ProdutoController(ProdutoContext context)
        {
            _context = context;

            if (_context.Produtos.Count() == 0)
            {
                //Create a new 'Produto' if collections is empty
                //wich means you can't delete all produtos

                _context.Produtos.Add(new Produto
                {
                    Name = "First1",
                    Descricao = "First1",
                    Vendedor = { Id = 1 },
                    Fornecedor = { Id = 1 }
                });
                _context.SaveChanges();
            }
        }

        //GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        //GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(long id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound();

            return produto;
        }

        //POST: api/Produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto item)
        {
            _context.Produtos.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = item.Id }, item);
        }

        //PUT: api/Produtos/5
        [HttpPut("id")]
        public async Task<ActionResult<Produto>> PutProduto(long id, Produto item)
        {
            if (id != item.Id)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return item;
        }

        //DELETE: api/Produtos/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Produto>> DeleteProduto(long id)
        //{
        //    var produto = await _context.Produtos.FindAsync(id);

        //    if (produto == null)
        //        return NotFound();

        //    _context.Produtos.Remove(produto);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}