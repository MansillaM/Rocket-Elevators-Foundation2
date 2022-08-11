using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsRestApi.Models;
using Microsoft.AspNetCore.Cors;

namespace RocketElevatorsRestApi.Controllers
{
    [EnableCors("MyAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class customersController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public customersController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<customers>>> Getcustomers()
        {
          if (_context.customers == null)
          {
              return NotFound();
          }
            return await _context.customers.ToListAsync();
        }

        // GET: api/customers/ignacio@vonrueden.net
        [HttpGet("{email}")]
        public async Task<ActionResult<customers>> GetCustomerIdFromEmail(string? email)
        {
          if (_context.customers == null)
          {
              return NotFound();
          }
            var customers = await _context.customers.Where(c => c.email == email).ToListAsync();

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        // PUT: api/customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcustomers(long id, customers customers)
        {
            if (id != customers.id)
            {
                return BadRequest();
            }

            _context.Entry(customers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customersExists(id))
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

        // POST: api/customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<customers>> Postcustomers(customers customers)
        {
          if (_context.customers == null)
          {
              return Problem("Entity set 'RocketElevatorsContext.customers'  is null.");
          }
            _context.customers.Add(customers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcustomers", new { id = customers.id }, customers);
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecustomers(long id)
        {
            if (_context.customers == null)
            {
                return NotFound();
            }
            var customers = await _context.customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            _context.customers.Remove(customers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool customersExists(long id)
        {
            return (_context.customers?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
