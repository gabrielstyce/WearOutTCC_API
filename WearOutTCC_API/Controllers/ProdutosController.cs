﻿using System;
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
    public class ProdutosController : ControllerBase
    {
        private readonly MyContextBase _context;

        public ProdutosController(MyContextBase context)
        {
            _context = context;

            if (_context.Produtos.Count() == 0)
            {
                _context.Produtos.Add(
                    new Produto {
                        Categoria = "First1",
                        Codigo = 1,
                        Descricao = "First1",
                        DtFornecida = DateTime.Now,
                        IdEstoque = 1,
                        Name = "First1",
                        NomeEstoque = "Estoque1",
                        Preco = 1.0m,
                        QtdFornecida = 2,
                        QtdProduto = 2,
                    });
                _context.SaveChanges();
            }
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(long id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(long id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        // POST: api/Produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.ProdutoId }, produto);
        }

        //// DELETE: api/Produtos/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Produto>> DeleteProduto(long id)
        //{
        //    var produto = await _context.Produtos.FindAsync(id);
        //    if (produto == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Produtos.Remove(produto);
        //    await _context.SaveChangesAsync();

        //    return produto;
        //}

        private bool ProdutoExists(long id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
