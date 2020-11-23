using System;
using System.Collections.Generic;
using net5_catalog.Entities;
using Microsoft.AspNetCore.Mvc;
using net5_catalog.Repositories;
using System.Linq;
using net5_catalog.Dtos;

namespace net5_catalog.Controllers 
{
    [ApiController]
    [Route("api/items")] 
    public class ItemsController: ControllerBase {
        private readonly IItemsRepository _repository; 
        public ItemsController(IItemsRepository repository)
        {
            _repository = repository;
        }

        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems() {
            var items = _repository.GetItems().Select(items => items.AsDto());
            return items;
        }


        // GET /items/id
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id) {
            var item = _repository.GetItem(id);
            if (item == null) {
                return NotFound();
            }
            return item.AsDto();
        }


        // POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(ItemCreateDto itemDto)
        {
            Item item = new() {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            _repository.CreateItem(item);

            return(CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto()));
        }

        // Put /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, ItemUpdateDto itemDto)
        {
            var existingItem = _repository.GetItem(id);
            if (existingItem == null) {
                return NotFound();
            }

            Item updatedItem = existingItem with {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            _repository.UpdateItem(updatedItem);

            return NoContent();
        }

        // Delete /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);
            if (existingItem == null) {
                return NotFound();
            }

            _repository.DeleteItem(id);

            return NoContent();
        }
    }
}