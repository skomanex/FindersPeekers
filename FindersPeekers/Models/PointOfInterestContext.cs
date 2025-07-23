using Microsoft.EntityFrameworkCore;

namespace FindersPeekers.Models
{
    public class PointOfInterestContext : DbContext
    {
        public PointOfInterestContext(DbContextOptions<PointOfInterestContext> options)
            : base(options)
        {
        }
        public DbSet<PointOfInterestItem> PointsOfInterest { get; set; }
    }
}
