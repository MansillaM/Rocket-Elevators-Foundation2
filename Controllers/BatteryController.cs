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
        public IEnumerable<Battery?> getAllBatteries(){
            var batteries = _context.Batteries.ToList();
            return batteries; 
        }

        [HttpGet("{id}")]
        public string? getBatteryStatus(long id){
            var batteries = _context.Batteries.Find(id);
            return batteries.Status;
        }

        [HttpPut("{id}/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Battery))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult editBatteryStatus(long id, string status ){
            var batteries = _context.Batteries.Find(id);
            try {
                _context.Entry(batteries).State = EntityState.Modified;
                batteries.Status = status;
                _context.SaveChanges();
            } catch {
                if(_context.Batteries.Find(id) == null) {
                    return NotFound();
                }
            }        
            return Ok(batteries);
        }  
    }
}