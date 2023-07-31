using AutoMapper;
using EndavaProject.Models;
using EndavaProject.Models.DTOs.InputDTOs;
using EndavaProject.Models.DTOs.OutputDTOs;
using EndavaProject.Repositories.CustomerRepositories;
using EndavaProject.Repositories.OrderRepositories;
using EndavaProject.Repositories.TicketCategoryRepositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EndavaProject.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderController(IOrderRepository orderRepository, IMapper mapper,
            ITicketCategoryRepository ticketCategoryRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _ticketCategoryRepository = ticketCategoryRepository;
            _customerRepository = customerRepository;
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

        [HttpPost]
        [Route($"api/{Constants.ControllerShortcut}/{Constants.ActionShortcut}")]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] OrderInDto orderTemplate)
        {
            if (orderTemplate.NumberOfTickets == 0)
                return BadRequest();
            var newOrder = _mapper.Map<Order>(orderTemplate);
            var ticketCategory = await _ticketCategoryRepository.Get(newOrder.TicketCategoryId);
            var customer = await _customerRepository.Get(newOrder.CustomersId);
            if (ticketCategory == null || customer == null)
                return BadRequest();
            newOrder.TotalPrice = newOrder.NumberOfTickets * ticketCategory.Price;
            await _orderRepository.Add(newOrder);
            var response = _mapper.Map<OrderDto>(newOrder);

            return Ok(response);
        }
    }
}