using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ZeroHunger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        FoodItemService service;

        public FoodItemController(FoodItemService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            return Ok(data);
        }

        [HttpPost("create")]
        public IActionResult Create(FoodItemModel p)
        {
            var data = service.Create(p);
            return Ok(data);
        }

        [HttpPut("update")]
        public IActionResult Update(FoodItemModel p)
        {
            var data = service.Update(p);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = service.Delete(id);
            return Ok(data);
        }
    }
}