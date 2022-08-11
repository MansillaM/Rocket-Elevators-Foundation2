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
    [Route("api/[controller]")]
    [ApiController]
    public class elevatorsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public elevatorsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<elevators>>> GetElevators()
        {
          if (_context.elevators == null)
          {
              return NotFound();
          }
            return await _context.elevators.ToListAsync();
        }

        // GET: api/Elevators/42
        [DisableCors]
        [HttpGet("{column_id}")]
        public async Task<ActionResult<elevators>> Getelevators(int column_id)
        {
          if (_context.elevators == null)
          {
              return NotFound();
          }
            var elevators = await _context.elevators.Where(e => e.column_id == column_id).ToListAsync();

            if (elevators == null)
            {
                return NotFound();
            }

            return Ok(elevators);
        }


        //GET api/elevators/inactive
        [HttpGet("inactive")]
        public object GetInactive()
        {
            return _context.elevators
                        .Where(elevator => elevator.elevator_status != "active");
                        // .Select(elevator => new {elevator.id, elevator.serial_number, elevator.status});
            
        }

        // PUT: api/elevators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public elevators editelevators(long id, elevators elevators){
            _context.Entry(elevators).State = EntityState.Modified;
            _context.SaveChanges();

                return elevators;
        }

        // POST: api/elevators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<elevators>> Postelevators(elevators elevators)
        {
          if (_context.elevators == null)
          {
              return Problem("Entity set 'RocketElevatorsContext.Elevators'  is null.");
          }
            _context.elevators.Add(elevators);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getelevators", new { id = elevators.id }, elevators);
        }

        // DELETE: api/elevators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteelevators(long id)
        {
            if (_context.elevators == null)
            {
                return NotFound();
            }
            var elevators = await _context.elevators.FindAsync(id);
            if (elevators == null)
            {
                return NotFound();
            }

            _context.elevators.Remove(elevators);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool elevatorsExists(long id)
        {
            return (_context.elevators?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
