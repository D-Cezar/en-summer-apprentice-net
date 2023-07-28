using AutoMapper;
using EndavaProject.Models.DTOs;
using EndavaProject.Repositories.OrderRepositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EndavaProject.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder([FromRoute] long id)
        {
            var order = await _orderRepository.Get(id);

            if (order == null) { return NotFound(); }
            var result = _mapper.Map<OrderDto>(order);

            return Ok(result);
        }

        [HttpGet]
        [Route($"api/{Constants.ControllerShortcut}")]
        public async Task<ActionResult<List<OrderDto>>> GetOrders()
        {
            var orders = await _orderRepository.GetAll();
            var result = _mapper.Map<List<OrderDto>>(orders);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/[controller]/[action]/{id}")]
        public async Task<ActionResult> DeleteOrder([FromRoute] long id)
        {
            var deletedOrderNumber = await _orderRepository.Delete(id);

            if (deletedOrderNumber == 0) { return NotFound(); };

            return Ok();
        }

        [HttpPatch]
        [Route("api/[controller]/[action]/{id}")]
        public async Task<ActionResult> PatchOrder([FromRoute] long id, JsonPatchDocument modifications)
        {
            var restrictedPaths = new HashSet<string> { "/OrderId", "/TotalPrice", "/CustomerId" };
            var containsRestrictedProperties = modifications.Operations.Any(x => restrictedPaths.Contains(x.path));
            if (containsRestrictedProperties) { return BadRequest(); }
            _orderRepository.Patch(id, modifications);
            return Ok();
        }
    }
}