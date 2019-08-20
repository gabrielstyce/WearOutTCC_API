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
    public class FornecedorController : Controller
    {
        private readonly FornecedorContext _context;

        public FornecedorController(FornecedorContext context)
        {
            _context = context;

            if (_context.Fornecedors.Count() == 0)
            {
                //Create a new 'Fornecedor' if collection is empty
                //wich means you can't delete all Fornecedors
                _context.Fornecedors.Add(new Fornecedor { FullName = "First1" });
                _context.SaveChanges();
            }
        }

        //GET: api/Fornecedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedors()
        {
            return await _context.Fornecedors.ToListAsync();
        }

        //GET: api/Fornecedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(long id)
        {
            var fornecedor = await _context.Fornecedors.FindAsync(id);

            if (fornecedor == null)
                return NotFound();

            return fornecedor;
        }

        //POST: api/Fornecedor/
        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor item)
        {
            _context.Fornecedors.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFornecedor), new Fornecedor { Id = item.Id }, item);
        }

        //PUT: api/Fornecedor/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Fornecedor>> PutFornecedor(long id, Fornecedor item)
        {
            if (id != item.Id)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return item;
        }

        //DELETE: api/Fornecedor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fornecedor>> DeleteFornecedor(long id)
        {
            var fornecedor = await _context.Fornecedors.FindAsync(id);

            if (fornecedor == null)
                return BadRequest();

            _context.Fornecedors.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
