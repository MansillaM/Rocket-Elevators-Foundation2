using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsRestApi.Models;

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

        // GET: api/Columns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Column>>> Getcolumns()
        {
          if (_context.Columns == null)
          {
              return NotFound();
          }
            return await _context.Columns.ToListAsync();
        }

        // GET: api/Columns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> GetColumn(int id)
        {
            if (_context.Columns == null)
            {
                return NotFound();
            }
            var column = await _context.Columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }

        // GET: api/Buildings/intervention
        [HttpGet("bldintervention")]
        public async Task<ActionResult<IEnumerable<Building>>> GetBldIntervention()
        {
            List<Building> Blds = await _context.Buildings.ToListAsync();
            List<Building> IntBlds = new List<Building>();
            List<Battery> Bats = await _context.Batteries.ToListAsync();
            List<Column> Cols = await _context.Columns.ToListAsync();
            List<elevators> Els = await _context.elevators.ToListAsync();
            
            foreach (Battery battery in Bats){
                if (battery.Status == "intervention"){
                    var building = await _context.Buildings.FindAsync(battery.Building_Id);
                    IntBlds.Add(building);
                }
            }

            foreach (Column column in Cols){
                if (column.status == "intervention"){
                    var battery = await _context.Batteries.FindAsync(column.battery_id);
                    var building = await _context.Buildings.FindAsync(battery.Building_Id);
                    IntBlds.Add(building);
                }
            }

             foreach (elevators elevator in Els){
                if (elevator.elevator_status == "intervention"){
                    var column = await _context.Columns.FindAsync(elevator.column_id);
                    var battery = await _context.Batteries.FindAsync(column.battery_id);
                    var building = await _context.Buildings.FindAsync(battery.Building_Id);
                    IntBlds.Add(building);
                }
            }

            return IntBlds;
        }
        private bool BuildingExists(int id)
        {
            return _context.Buildings.Any(e => e.id == id);
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
        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<Column>> PutColumn(int id, string status)
        {
            var column = await _context.Columns.FindAsync(id);
            column.status = status;
            _context.Entry(column).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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
            return (_context.Columns?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
