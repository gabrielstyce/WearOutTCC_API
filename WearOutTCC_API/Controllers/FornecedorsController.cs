using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WearOutTCC_API.Models;

namespace WearOutTCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorsController : ControllerBase
    {
        private readonly MyContextBase _context;

        public FornecedorsController(MyContextBase context)
        {
            _context = context;

            if (_context.Fornecedors.Count() == 0)
            {
                _context.Fornecedors.Add(
                    new Fornecedor {
                        tipo = 'V'
                    });
                _context.SaveChanges();
            }
        }

        // GET: api/Fornecedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedors()
        {
            return await _context.Fornecedors.ToListAsync();
        }

        // GET: api/Fornecedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(long id)
        {
            var fornecedor = await _context.Fornecedors.FindAsync(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return fornecedor;
        }

        // PUT: api/Fornecedors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(long id, Fornecedor fornecedor)
        {
            if (id != fornecedor.UserId)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fornecedors
        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedors.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.UserId }, fornecedor);
        }

        //// DELETE: api/Fornecedors/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Fornecedor>> DeleteFornecedor(long id)
        //{
        //    var fornecedor = await _context.Fornecedors.FindAsync(id);
        //    if (fornecedor == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Fornecedors.Remove(fornecedor);
        //    await _context.SaveChangesAsync();

        //    return fornecedor;
        //}

        private bool FornecedorExists(long id)
        {
            return _context.Fornecedors.Any(e => e.UserId == id);
        }
    }
}
