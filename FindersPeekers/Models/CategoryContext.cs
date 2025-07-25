using Microsoft.EntityFrameworkCore;

namespace FindersPeekers.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options)
    : base(options)
        {
        }
        public DbSet<CategoryItem> PointsOfInterest { get; set; }

    }
}
