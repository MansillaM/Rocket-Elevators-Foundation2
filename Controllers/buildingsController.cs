using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsRestApi.Models;

namespace RocketElevatorsRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class buildingsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public buildingsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<building>>> Getbuildings()
        {
          if (_context.buildings == null)
          {
              return NotFound();
          }
            return await _context.buildings.ToListAsync();
        }

        // GET: api/buildings/1
        [HttpGet("{customer_id}")]
        public async Task<ActionResult<building>> Getcustomerbuilding(long customer_id)
        {
          if (_context.buildings == null)
          {
              return NotFound();
          }
            var building = await _context.buildings.Where(b => b.customer_id == customer_id).ToListAsync();

            if (building == null)
            {
                return NotFound();
            }

            return Ok(building);
        }

        // PUT: api/buildings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbuilding(long id, building building)
        {
            if (id != building.id)
            {
                return BadRequest();
            }

            _context.Entry(building).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!buildingExists(id))
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

        // POST: api/buildings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<building>> Postbuilding(building building)
        {
          if (_context.buildings == null)
          {
              return Problem("Entity set 'RocketElevatorsContext.buildings'  is null.");
          }
            _context.buildings.Add(building);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbuilding", new { id = building.id }, building);
        }

        // DELETE: api/buildings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebuilding(long id)
        {
            if (_context.buildings == null)
            {
                return NotFound();
            }
            var building = await _context.buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            _context.buildings.Remove(building);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool buildingExists(long id)
        {
            return (_context.buildings?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
