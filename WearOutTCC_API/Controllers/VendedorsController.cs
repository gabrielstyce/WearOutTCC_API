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
    public class VendedorsController : ControllerBase
    {
        private readonly MyContextBase _context;

        public VendedorsController(MyContextBase context)
        {
            _context = context;

            if (_context.Vendedors.Count() == 0)
            {
                _context.Vendedors.Add(
                    new Vendedor
                    {
                        tipo = 'V'
                    });
                _context.SaveChanges();
            }
        }

        // GET: api/Vendedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedors()
        {
            return await _context.Vendedors.ToListAsync();
        }

        // GET: api/Vendedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(long id)
        {
            var vendedor = await _context.Vendedors.FindAsync(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            return vendedor;
        }

        // PUT: api/Vendedors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedor(long id, Vendedor vendedor)
        {
            if (id != vendedor.UserId)
            {
                return BadRequest();
            }

            _context.Entry(vendedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedorExists(id))
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

        // POST: api/Vendedors
        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor(Vendedor vendedor)
        {
            _context.Vendedors.Add(vendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendedor", new { id = vendedor.UserId }, vendedor);
        }

        //// DELETE: api/Vendedors/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Vendedor>> DeleteVendedor(long id)
        //{
        //    var vendedor = await _context.Vendedors.FindAsync(id);
        //    if (vendedor == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Vendedors.Remove(vendedor);
        //    await _context.SaveChangesAsync();

        //    return vendedor;
        //}

        private bool VendedorExists(long id)
        {
            return _context.Vendedors.Any(e => e.UserId == id);
        }
    }
}
