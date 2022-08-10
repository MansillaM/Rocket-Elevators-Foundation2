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
    public class BatteryController : ControllerBase 
    {
        // class properties
        private readonly RocketElevatorsContext _context;
        // constructor
        public BatteryController(RocketElevatorsContext context){
        _context = context;
        }

        // REST 
        [HttpGet("all")] // ENDPOINT: /api/battery/all
        public IEnumerable<battery?> getAllBatteries(){
            var batteries = _context.batteries.ToList();
            return batteries; 
        }

        // GET: api/battery/20
        [HttpGet("{building_id}")]
        public async Task<ActionResult<battery>> Getbatteries(long building_id)
        {
          if (_context.batteries == null)
          {
              return NotFound();
          }
            var batteries = await _context.batteries.Where(b => b.building_id == building_id).ToListAsync();

            if (batteries == null)
            {
                return NotFound();
            }

            return Ok(batteries);
        }

        [HttpPut("{id}")]
        public battery editbatteriess(long id, battery battery){
            _context.Entry(battery).State = EntityState.Modified;
            _context.SaveChanges();

                return battery;
        }
    }
}