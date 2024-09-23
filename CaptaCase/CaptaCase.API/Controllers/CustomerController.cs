using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerSchema.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaptaCase.API.Controllers
{
    [ApiController]
    [Route("api/customer/[controller]")]
    [ApiExplorerSettings(GroupName = "customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator _mediator;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public Task<Result<CustomerResponse>> Get([FromQuery] GetCustomerRequest request) =>
                _mediator.Send(request);

        [HttpGet("list")]
        public Task<PaginatedResult<CustomerResponse>> Get() =>
                _mediator.Send(new ListCustomerRequest());

        [HttpPost()]
        public Task<Result> Post([FromBody] SaveCustomerRequest request) =>
                _mediator.Send(request);

        [HttpPost("update")]
        public Task<Result> Update([FromBody] UpdateCustomerRequest request) =>
                _mediator.Send(request);

        [HttpDelete()]
        public Task<Result> Delete([FromQuery] DeleteCustomerRequest request) =>
                _mediator.Send(request);
    }
}