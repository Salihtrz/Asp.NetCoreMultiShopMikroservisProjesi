using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            // Send metodunun içinde IRequestten miras alan sınıf çağırılmalıdır.
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
        {
            await _mediator.Send(createOrderingCommand);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediator.Send(updateOrderingCommand);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok();
        }
    }
}
