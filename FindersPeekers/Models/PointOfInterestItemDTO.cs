namespace FindersPeekers.Models
{
    public class PointOfInterestItemDTO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }
        public required string Category { get; set; }
    }
}
