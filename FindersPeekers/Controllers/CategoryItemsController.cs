using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FindersPeekers.Models;

namespace FindersPeekers.Controllers
{
    [Route("Categories")]
    [ApiController]
    public class CategoryItemsController : ControllerBase
    {
        private readonly CategoryContext _context;

        public CategoryItemsController(CategoryContext context)
        {
            _context = context;
        }

        // GET: api/CategoryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryItem>>> GetPointsOfInterest()
        {
            return await _context.PointsOfInterest.ToListAsync();
        }

        // GET: api/CategoryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryItem>> GetCategoryItem(int id)
        {
            var categoryItem = await _context.PointsOfInterest.FindAsync(id);

            if (categoryItem == null)
            {
                return NotFound();
            }

            return categoryItem;
        }

        // PUT: api/CategoryItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryItem(int id, CategoryItem categoryItem)
        {
            if (id != categoryItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryItemExists(id))
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

        // POST: api/CategoryItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryItem>> PostCategoryItem(CategoryItem categoryItem)
        {
            _context.PointsOfInterest.Add(categoryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoryItem), new { id = categoryItem.Id }, categoryItem);
        }

        // DELETE: api/CategoryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryItem(int id)
        {
            var categoryItem = await _context.PointsOfInterest.FindAsync(id);
            if (categoryItem == null)
            {
                return NotFound();
            }

            _context.PointsOfInterest.Remove(categoryItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryItemExists(int id)
        {
            return _context.PointsOfInterest.Any(e => e.Id == id);
        }
    }
}
