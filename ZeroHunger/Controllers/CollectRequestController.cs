using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ZeroHunger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectRequestController : ControllerBase
    {
        CollectRequestService service;

        public CollectRequestController(CollectRequestService service)
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
        public IActionResult Create(CollectRequestModel p)
        {
            var data = service.Create(p);
            return Ok(data);
        }

        [HttpPut("update")]
        public IActionResult Update(CollectRequestModel p)
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
        [HttpPut("accept/{id}")]
        public IActionResult Accept(int id)
        {
            var data = service.Accept(id);

            return Ok(data);
        }
        [HttpPut("assign/{requestId}/{employeeId}")]
        public IActionResult AssignEmployee(int requestId, int employeeId)
        {
            var data = service.AssignEmployee(requestId, employeeId);

            return Ok(data);
        }
        [HttpPut("collect/{id}")]
        public IActionResult Collect(int id)
        {
            var data = service.MarkCollected(id);

            return Ok(data);
        }
        [HttpGet("pending")]
        public IActionResult Pending()
        {
            var data = service.GetPending();

            return Ok(data);
        }
        [HttpGet("accepted")]
        public IActionResult GetAccepted()
        {
            var data = service.GetAccepted();

            return Ok(data);
        }
        [HttpGet("assigned")]
        public IActionResult Assigned()
        {
            var data = service.GetAssigned();

            return Ok(data);
        }
        [HttpGet("collected")]
        public IActionResult Collected()
        {
            var data = service.GetCollected();

            return Ok(data);
        }
        [HttpGet("completed")]
        public IActionResult Completed()
        {
            var data = service.GetCompleted();

            return Ok(data);
        }
        [HttpGet("restaurant/{restaurantId}")]
        public IActionResult GetByRestaurant(int restaurantId)
        {
            var data = service.GetByRestaurant(restaurantId);

            return Ok(data);
        }
        [HttpGet("employee/{employeeId}")]
        public IActionResult GetByEmployee(int employeeId)
        {
            var data = service.GetByEmployee(employeeId);

            return Ok(data);
        }
    }
}