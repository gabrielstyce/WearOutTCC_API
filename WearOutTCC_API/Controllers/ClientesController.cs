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
    public class ClientesController : ControllerBase
    {
        private readonly MyContextBase _context;

        public ClientesController(MyContextBase context)
        {
            _context = context;

            try
            {
                if (_context.Clientes.Count() == 0)
                {
                    //Create a new 'Cliete' if collections is empty
                    //wich means you can't delete all clientes
                    _context.Clientes.Add(
                        new Cliente
                        {
                            tipo = 'C'
                        });
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(long id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(long id, Cliente cliente)
        {
            if (id != cliente.UserId)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCliente", new { id = cliente.UserId }, cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //// DELETE: api/Clientes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Cliente>> DeleteCliente(long id)
        //{
        //    var cliente = await _context.Clientes.FindAsync(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Clientes.Remove(cliente);
        //    await _context.SaveChangesAsync();

        //    return cliente;
        //}

        private bool ClienteExists(long id)
        {
            return _context.Clientes.Any(e => e.UserId == id);
        }
    }
}
