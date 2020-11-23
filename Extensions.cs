using net5_catalog.Dtos;
using net5_catalog.Entities;

namespace net5_catalog
{
    public static class Extensions {
        public static ItemDto AsDto(this Item item) {
            return new ItemDto {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }        
    }
}