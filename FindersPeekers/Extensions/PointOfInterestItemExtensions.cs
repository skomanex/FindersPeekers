using FindersPeekers.Models;

namespace FindersPeekers.Extensions
{
    public static class PointOfInterestItemExtensions
    {
        private enum PointOfInterestCategory
        {
            Park,
            Museum,
            Restaurant,
            HistoricSite,
            Other
        }
        public static PointOfInterestItemDTO ToDTO(this PointOfInterestItem item)
        {
            return new PointOfInterestItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                Category = ((PointOfInterestCategory)item.Category).ToString()
            };
        }

        public static PointOfInterestItem ToEntity(this PointOfInterestItemDTO dto)
        {
            if (!Enum.TryParse<PointOfInterestCategory>(dto.Category, out var category))
            {
                category = PointOfInterestCategory.Other;
            }
            return new PointOfInterestItem
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Category = (int)category
            };
        }
    }
}
