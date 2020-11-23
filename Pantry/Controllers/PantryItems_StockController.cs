using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantry.Data;
using Pantry.Models;

namespace Pantry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PantryItems_StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PantryItems_StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/PantryItems_Stock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PantryItems_Stock>>> GetPantryItems_Stock()
        {
            var Items = _context.PantryItems_Stock.Include(a => a.PantryItems).ThenInclude(a => a.Categories);
            return await Items.ToListAsync();
        }

        // GET: api/PantryItems_Stock/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PantryItems_Stock>> GetPantryItems_Stock(Guid id)
        {
            var pantryItems_Stock = await _context.PantryItems_Stock.FindAsync(id);

            if (pantryItems_Stock == null)
            {
                return NotFound();
            }

            return pantryItems_Stock;
        }

        // PUT: api/PantryItems_Stock/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPantryItems_Stock(Guid id, PantryItems_Stock pantryItems_Stock)
        {
            if (id != pantryItems_Stock.StockID)
            {
                return BadRequest();
            }

            _context.Entry(pantryItems_Stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PantryItems_StockExists(id))
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

        // POST: api/PantryItems_Stock
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PantryItems_Stock>> PostPantryItems_Stock(PantryItems_Stock pantryItems_Stock)
        {
            _context.PantryItems_Stock.Add(pantryItems_Stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPantryItems_Stock", new { id = pantryItems_Stock.StockID }, pantryItems_Stock);
        }

        // DELETE: api/PantryItems_Stock/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<PantryItems_Stock>> DeletePantryItems_Stock(Guid id)
        {
            var pantryItems_Stock = await _context.PantryItems_Stock.FindAsync(id);
            if (pantryItems_Stock == null)
            {
                return NotFound();
            }

            _context.PantryItems_Stock.Remove(pantryItems_Stock);
            await _context.SaveChangesAsync();

            return pantryItems_Stock;
        }

        private bool PantryItems_StockExists(Guid id)
        {
            return _context.PantryItems_Stock.Any(e => e.StockID == id);
        }
    }
}
