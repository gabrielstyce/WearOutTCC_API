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
    public class VendedorController : ControllerBase
    {
        private readonly VendedorContext _context;

        public VendedorController(VendedorContext context)
        {
            _context = context;

            if (_context.Vendedors.Count() == 0)
            {
                //Create a new 'Vendedor' if collections is empty,
                //wich means you can't delete all vendedors.
                _context.Vendedors.Add(new Vendedor { FullName = "First1", VendedorId = 1 });
                _context.SaveChanges();
            }
        }

        //GET: api/Vendedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedors()
        {
            return await _context.Vendedors.ToListAsync();
        }

        //GET: api/Vendedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(long id)
        {
            var vendedor = await _context.Vendedors.FindAsync(id);

            if (vendedor == null)
                return NotFound();

            return vendedor;
        }

        //POST: api/Vendedor
        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor(Vendedor item)
        {
            _context.Vendedors.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVendedor), new { id = item.Id }, item);
        }
        
        //PUT: api/Vendedor/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Vendedor>> PutVendedor(long id, Vendedor item)
        {
            if (id != item.Id)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return item;
        }

        //DELETE: api/Vendedor/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Vendedor>> DeleteVendedor(long id)
        //{
        //    var vendedor = await _context.Vendedors.FindAsync(id);

        //    if (vendedor == null)
        //        return NotFound();

        //    _context.Vendedors.Remove(vendedor);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
