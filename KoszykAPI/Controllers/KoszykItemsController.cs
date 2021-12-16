using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoszykAPI.Models;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace KoszykAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoszykItemsController : ControllerBase
    {
        private readonly KoszykContext _context;

        public KoszykItemsController(KoszykContext context)
        {
            _context = context;
        }

        // GET: api/KoszykItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KoszykItem>>> GetKoszykItems()
        {
            return await _context.KoszykItems.ToListAsync();
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [SwaggerOperation("Zwraca towar o podanym {id}.", "Używa EF FindAsync()")]

        [SwaggerResponse(404, "Nie znaleziono towaru o podanym {id}")]
        public async Task<ActionResult<KoszykItem>> GetKoszykItem(int id)
        {
            var koszykItem = await _context.KoszykItems.FindAsync(id);

            if (koszykItem == null)
            {
                return NotFound();
            }

            return koszykItem;
        }

        // PUT: api/KoszykItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKoszykItem(int id, KoszykItem koszykItem)
        {
            if (id != koszykItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(koszykItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoszykItemExists(id))
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

        // POST: api/KoszykItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KoszykItem>> PostKoszykItem(KoszykItem koszykItem)
        {
            _context.KoszykItems.Add(koszykItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKoszykItem", new { id = koszykItem.Id }, koszykItem);

        }
        // DELETE: api/KoszykItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKoszykItem(int id)
        {
            var koszykItem = await _context.KoszykItems.FindAsync(id);
            if (koszykItem == null)
            {
                return NotFound();
            }

            _context.KoszykItems.Remove(koszykItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KoszykItemExists(int id)
        {
            return _context.KoszykItems.Any(e => e.Id == id);
        }

    }
}
