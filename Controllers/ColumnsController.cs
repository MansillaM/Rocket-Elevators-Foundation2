using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsRestApi.Models;
using Microsoft.AspNetCore.Cors;

namespace RocketElevatorsRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public ColumnsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/Columns/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<column>>> Getcolumns()
        {
          if (_context.columns == null)
          {
              return NotFound();
          }
            return await _context.columns.ToListAsync();
        }

        // GET: api/Columns/inactive
        [HttpGet("inactive")]
        public object GetInactive()
        {
            return _context.columns
                        .Where(column => column.status != "active");
            
        }

        // GET: api/Columns/52
        [DisableCors]
        [HttpGet("{battery_id}")]
        public async Task<ActionResult<column>> GetColumn(int battery_id)
        {
            if (_context.columns == null)
            {
                return NotFound();
            }
            var column = await _context.columns.Where(c => c.battery_id == battery_id).ToListAsync();

            if (column == null)
            {
                return NotFound();
            }

            return Ok(column);
        }

        [HttpGet("bldintervention")]
        public async Task<ActionResult<IEnumerable<building>>> GetBldIntervention()
        {
            List<building> Blds = await _context.buildings.ToListAsync();
            List<building> IntBlds = new List<building>();
            List<battery> Bats = await _context.batteries.ToListAsync();
            List<column> Cols = await _context.columns.ToListAsync();
            List<elevators> Els = await _context.elevators.ToListAsync();
            
            foreach (battery battery in Bats){
                if (battery.Status == "intervention"){
                    var building = await _context.buildings.FindAsync(battery.building_id);
                    IntBlds.Add(building);
                }
            }

            foreach (column column in Cols){
                if (column.status == "intervention"){
                    var battery = await _context.batteries.FindAsync(column.battery_id);
                    var building = await _context.buildings.FindAsync(battery.building_id);
                    IntBlds.Add(building);
                }
            }

             foreach (elevators elevator in Els){
                if (elevator.elevator_status == "intervention"){
                    var column = await _context.columns.FindAsync(elevator.column_id);
                    var battery = await _context.batteries.FindAsync(column.battery_id);
                    var building = await _context.buildings.FindAsync(battery.building_id);
                    IntBlds.Add(building);
                }
            }

            return IntBlds;
        }
        private bool BuildingExists(int id)
        {
            return _context.buildings.Any(e => e.id == id);
        }

        // // GET: api/columns/batinactive
        // [HttpGet("bldintervention")]
        // public IEnumerable<Building> getInactiveBuildings()
        // {
        //     IQueryable<Building> inacObj = 
        //     from bld in _context.buildings
        //     join ba in _context.batteries on bld.id equals ba.building_id 
        //     join c in _context.columns on ba.id equals c.battery_id
        //     join el in _context.elevators on c.id equals el.column_id
        //     where /*el.elevator_status == "intervention" || */c.status == "intervention" || ba.status == "intervention"
        //     select bld;

        //     return inacObj.Distinct();
        //     //return inacObj.Distinct();
        //     //c.status == "intervention"
        // }

        // private bool BuildingItemExists(long id)
        //     {
        //     return _context.buildings.Any(e => e.id == id);
        //     }

        // PUT: api/Columns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public column editcolumn(long id, column column){
            _context.Entry(column).State = EntityState.Modified;
            _context.SaveChanges();

                return column;
        }

        // // POST: api/Columns
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Column>> PostColumn(Column column)
        // {
        //   if (_context.columns == null)
        //   {
        //       return Problem("Entity set 'ApplicationContext.columns'  is null.");
        //   }
        //     _context.columns.Add(column);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetColumn", new { id = column.id }, column);
        // }

        // // DELETE: api/Columns/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteColumn(int id)
        // {
        //     if (_context.columns == null)
        //     {
        //         return NotFound();
        //     }
        //     var column = await _context.columns.FindAsync(id);
        //     if (column == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.columns.Remove(column);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool ColumnExists(int id)
        {
            return (_context.columns?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
