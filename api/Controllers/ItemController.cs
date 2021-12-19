using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportSystemAPI.Data.Item;
using SportSystemAPI.Model;

namespace SportSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        public ItemController(IItemRepo repository)
        {
            _repository = repository;
        }

        public readonly IItemRepo _repository;

        // GET api/item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemModel>>> GetItemListAsync()
        {
            var itemList = await _repository.GetItemListAsync();
            if (itemList is null)
            {
                return NotFound();
            }
            return Ok(itemList);
        }


        // GET api/item/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> GetItemByIdAsync([FromRoute] int id)
        {
            var itemFromRepo = await _repository.GetItemByIdAsync(id);
            if (itemFromRepo is null)
            {
                return NotFound();
            }
            return Ok(itemFromRepo);
        }

        // GET api/item/name{name}
        [HttpGet("name/{name}")]
        public async Task<ActionResult<ItemModel>> GetItemByNameAsync([FromRoute] string name)
        {
            var itemFromRepo = await _repository.GetItemByNameAsync(name);
            if (itemFromRepo is null)
            {
                return NotFound();
            }
            return Ok(itemFromRepo);
        }

        // GET api/item/{userId}
        [HttpGet("list/{userId}")]
        public async Task<ActionResult<List<ItemModel>>> GetItemListByUserIdAsync([FromRoute] int userId)
        {
            var itemFromRepo = await _repository.GetItemListByUserIdAsync(userId);
            if (itemFromRepo is null)
            {
                return NotFound();
            }
            return Ok(itemFromRepo);
        }

        // POST api/item
        [HttpPost]
        public async Task<ActionResult> CreateItemAsync([FromBody] ItemModel itemModel)
        {
            await _repository.CreateItemAsync(itemModel);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // PUT api/item
        [HttpPut]
        public async Task<ActionResult> UpdateItemAsync([FromBody] ItemModel itemModel)
        {
            var model = await _repository.GetItemByIdAsync(itemModel.Id);
            // model.Name = itemModel.Name ?? model.Name;
            // model.Picture = itemModel.Picture ?? model.Picture;
            // model.Price = itemModel.Price ?? model.Price;
            // model.Description = itemModel.Description ?? model.Description;
            // model.Quantity = itemModel.Quantity ?? model.Quantity;
            // model.Discount = itemModel.Discount ?? model.Discount;
            // model.Type = itemModel.Type ?? model.Type;

            model.Name = !String.IsNullOrEmpty(itemModel.Name) ? itemModel.Name : model.Name;
            model.Picture = !String.IsNullOrEmpty(itemModel.Picture) ? itemModel.Picture : model.Picture;
            model.Price = itemModel.Price != null ? itemModel.Price : model.Price;
            model.Description = !String.IsNullOrEmpty(itemModel.Description) ? itemModel.Description : model.Description;
            model.Quantity = itemModel.Quantity != null ? itemModel.Quantity : model.Quantity;
            model.Discount = itemModel.Discount != null ? itemModel.Discount : model.Discount;
            model.Type = !String.IsNullOrEmpty(itemModel.Type) ? itemModel.Type : model.Type;

            await _repository.UpdateItemAsync(model);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // Delete api/item/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemByIdAsync([FromRoute] int id)
        {

            var item = await _repository.GetItemByIdAsync(id);
            if (item is null)
                return NotFound("Not a valid item id");

            await _repository.DeleteItemAsync(item);

            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}