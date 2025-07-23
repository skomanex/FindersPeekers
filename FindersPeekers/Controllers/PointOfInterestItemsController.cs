using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FindersPeekers.Models;
using FindersPeekers.Extensions;

namespace FindersPeekers.Controllers
{
    [Route("PointsOfInterest")]
    [ApiController]
    public class PointOfInterestItemsController : ControllerBase
    {
        private readonly PointOfInterestContext _context;

        public PointOfInterestItemsController(PointOfInterestContext context)
        {
            _context = context;
        }

        // GET: PointsOfInterest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestItemDTO>>> GetPointsOfInterest()
        {
            var items = await _context.PointsOfInterest.ToListAsync();
            return items.Select(i => i.ToDTO()).ToList();
        }

        // GET: PointsOfInterest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PointOfInterestItemDTO>> GetPointOfInterestItem(long id)
        {
            var pointOfInterestItem = await _context.PointsOfInterest.FindAsync(id);

            if (pointOfInterestItem == null)
            {
                return NotFound();
            }

            return pointOfInterestItem.ToDTO();
        }

        // PUT: PointsOfInterest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPointOfInterestItem(long id, PointOfInterestItem entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointOfInterestItemExists(id))
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

        // POST: PointsOfInterest
        [HttpPost]
        public async Task<ActionResult<PointOfInterestItemDTO>> PostPointOfInterestItem(PointOfInterestItem entity)
        {
            _context.PointsOfInterest.Add(entity);
            await _context.SaveChangesAsync();

            var resultDto = entity.ToDTO();
            return CreatedAtAction(nameof(GetPointOfInterestItem), new { id = entity.Id }, resultDto);
        }

        // DELETE: PointsOfInterest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePointOfInterestItem(long id)
        {
            var pointOfInterestItem = await _context.PointsOfInterest.FindAsync(id);
            if (pointOfInterestItem == null)
            {
                return NotFound();
            }

            _context.PointsOfInterest.Remove(pointOfInterestItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PointOfInterestItemExists(long id)
        {
            return _context.PointsOfInterest.Any(e => e.Id == id);
        }
    }
}
