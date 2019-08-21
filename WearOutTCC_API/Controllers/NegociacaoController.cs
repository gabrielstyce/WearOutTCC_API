using System;
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
    public class NegociacaoController : ControllerBase
    {
        private readonly NegociacaoContext _context;

        public NegociacaoController(NegociacaoContext context)
        {
            _context = context;

            if (_context.Negociacoes.Count() == 0)
            {
                _context.Negociacoes.Add(new Negociacao
                {
                    QtdProduto = 0,
                    DtNegociacao = DateTime.Now,
                    ValorTotal = 0.00m,
                    Cliente = { Id = 1 },
                    Produto = { Id = 1 },
                    Vendedor = { Id = 1, VendedorId = 1 },
                });
                _context.SaveChanges();
            }
        }

        //GET: api/Negociacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negociacao>>> GetNegociacoes()
        {
            return await _context.Negociacoes.ToListAsync();
        }

        //GET: api/Negociacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Negociacao>> GetNegociacao(long id)
        {
            var negociacao = await _context.Negociacoes.FindAsync(id);

            if (negociacao == null)
                return NotFound();

            return negociacao;
        }

        //POST: api/Negociacoes
        [HttpPost]
        public async Task<ActionResult<Negociacao>> PostNegociacao(Negociacao item)
        {
            _context.Negociacoes.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNegociacao), new { id = item.Id }, item);
        }

        //PUT: api/Negociacoes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Negociacao>> PutNegociacao(long id, Negociacao item)
        {
            if (id != item.Id)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return item;
        }

        //DELETE: api/Negociacoes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Negociacao>> DeleteNegociacao(long id)
        //{
        //    var negociacao = await _context.Negociacoes.FindAsync();

        //    if (negociacao == null)
        //        return NotFound();

        //    _context.Negociacoes.Remove(negociacao);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}