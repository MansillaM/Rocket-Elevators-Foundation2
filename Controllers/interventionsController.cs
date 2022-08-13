using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsRestApi.Models;
using RocketElevatorsRestApi.models;

namespace RocketElevatorsRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class interventionsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public interventionsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/interventions
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<interventions>>> Getinterventions()
        // {

        // //   if (_context.interventions == null)
        // //   {
        // //       return NotFound();
        // //   }
        //     return await _context.interventions.ToListAsync();
        // }

        // GET: api/interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<interventions>>> GetInterventions()
        {
          if (_context.interventions == null)
          {
              return NotFound();
          }
            return await _context.interventions.ToListAsync();
        }

        // PUT: api/interventions/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{author}/{customer_id}/{building_id}/{battery_id}/{column_id}/{elevator_id}/{report}")]
        public interventions Putinterventions(long id, interventions interventions)
        {
            _context.Entry(interventions).State = EntityState.Modified;
            _context.SaveChanges();

                return interventions;
        }

        // POST: api/interventions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{author}/{customer_id}/{building_id}/{battery_id}/{column_id}/{elevator_id}/{report}")]
        public async Task<ActionResult<interventions>> Postinterventions(interventions interventions)
        {
          if (_context.interventions == null)
          {
              return Problem("Entity set 'RocketElevatorsContext.interventions'  is null.");
          }
            _context.interventions.Add(interventions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getinterventions", new { id = interventions.id }, interventions);
        }

        // DELETE: api/interventions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteinterventions(long id)
        {
            if (_context.interventions == null)
            {
                return NotFound();
            }
            var interventions = await _context.interventions.FindAsync(id);
            if (interventions == null)
            {
                return NotFound();
            }

            _context.interventions.Remove(interventions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool interventionsExists(long id)
        {
            return (_context.interventions?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
