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
    public class NegociacaosController : ControllerBase
    {
        private readonly MyContextBase _context;

        public NegociacaosController(MyContextBase context)
        {
            _context = context;

            if (_context.Negociacoes.Count() == 0)
            {
                
                _context.Negociacoes.Add(
                    new Negociacao
                {
                    DtNegociacao = DateTime.Now,
                    ValorTotal = 1.00m
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Negociacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negociacao>>> GetNegociacoes()
        {
            return await _context.Negociacoes.ToListAsync();
        }

        // GET: api/Negociacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Negociacao>> GetNegociacao(long id)
        {
            var negociacao = await _context.Negociacoes.FindAsync(id);

            if (negociacao == null)
            {
                return NotFound();
            }

            return negociacao;
        }

        // PUT: api/Negociacaos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNegociacao(long id, Negociacao negociacao)
        {
            if (id != negociacao.NegociacaoId)
            {
                return BadRequest();
            }

            _context.Entry(negociacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NegociacaoExists(id))
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

        // POST: api/Negociacaos
        [HttpPost]
        public async Task<ActionResult<Negociacao>> PostNegociacao(Negociacao negociacao)
        {
            _context.Negociacoes.Add(negociacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNegociacao", new { id = negociacao.NegociacaoId }, negociacao);
        }

        //// DELETE: api/Negociacaos/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Negociacao>> DeleteNegociacao(long id)
        //{
        //    var negociacao = await _context.Negociacoes.FindAsync(id);
        //    if (negociacao == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Negociacoes.Remove(negociacao);
        //    await _context.SaveChangesAsync();

        //    return negociacao;
        //}

        private bool NegociacaoExists(long id)
        {
            return _context.Negociacoes.Any(e => e.NegociacaoId == id);
        }
    }
}
