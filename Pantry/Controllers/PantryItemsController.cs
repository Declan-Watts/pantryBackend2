using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantry.Data;
using Pantry.Models;

namespace Pantry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PantryItemsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PantryItemsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/PantryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PantryItems>>> GetPantryItems()
        {
            var Items = _context.PantryItems.Include(a => a.Categories).Include(a => a.PantryItems_Stock);
            return await Items.ToListAsync();
        }

        // GET: api/PantryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PantryItems>> GetPantryItems(Guid id)
        {
            var pantryItems = await _context.PantryItems.FindAsync(id);

            if (pantryItems == null)
            {
                return NotFound();
            }

            return pantryItems;
        }

        // PUT: api/PantryItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPantryItems(Guid id, PantryItems pantryItems)
        {
            if (id != pantryItems.PantryItemsID)
            {
                return BadRequest();
            }

            _context.Entry(pantryItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PantryItemsExists(id))
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

        // POST: api/PantryItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PantryItems>> PostPantryItems(PantryItems pantryItems)
        {
            _context.PantryItems.Add(pantryItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPantryItems", new { id = pantryItems.PantryItemsID }, pantryItems);
        }

        // DELETE: api/PantryItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PantryItems>> DeletePantryItems(Guid id)
        {
            var pantryItems = await _context.PantryItems.FindAsync(id);
            if (pantryItems == null)
            {
                return NotFound();
            }

            _context.PantryItems.Remove(pantryItems);
            await _context.SaveChangesAsync();

            return pantryItems;
        }

        private bool PantryItemsExists(Guid id)
        {
            return _context.PantryItems.Any(e => e.PantryItemsID == id);
        }
    }
}
