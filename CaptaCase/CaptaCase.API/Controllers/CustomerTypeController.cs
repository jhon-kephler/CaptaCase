using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerTypeSchema.Request;
using CaptaCase.Core.Schema.CustomerTypeSchema.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaptaCase.API.Controllers
{
    [ApiController]
    [Route("api/customertype/[controller]")]
    [ApiExplorerSettings(GroupName = "customertype")]
    public class CustomerTypeController : ControllerBase
    {
        private readonly ILogger<CustomerTypeController> _logger;
        private readonly IMediator _mediator;

        public CustomerTypeController(ILogger<CustomerTypeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public Task<Result<CustomerTypeResponse>> Get([FromQuery] GetCustomerTypeRequest request) =>
                _mediator.Send(request);

        [HttpGet("list")]
        public Task<PaginatedResult<CustomerTypeResponse>> Get() =>
                _mediator.Send(new ListCustomerTypeRequest());

        [HttpPost()]
        public Task<Result> Post([FromBody] SaveCustomerTypeRequest request) =>
                _mediator.Send(request);

        [HttpPost("update")]
        public Task<Result> Update([FromBody] UpdateCustomerTypeRequest request) =>
                _mediator.Send(request);

        [HttpDelete()]
        public Task<Result> Delete([FromQuery] DeleteCustomerTypeRequest request) =>
                _mediator.Send(request);
    }
}