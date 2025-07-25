using FindersPeekers.Models;
using System.Collections.Generic;
using System.Linq;

namespace FindersPeekers.Extensions
{
    public static class PointOfInterestItemExtensions
    {
        public static PointOfInterestItemDTO ToDTO(this PointOfInterestItem item)
        {
            return new PointOfInterestItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                Category = ""
            };
        }

        public static PointOfInterestItem ToEntity(this PointOfInterestItemDTO dto)
        {
            return new PointOfInterestItem
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Category = 0
            };
        }
    }
}
