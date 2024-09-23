using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerSchema.Response;
using CaptaCase.Core.Schema.CustomerSituationSchema.Request;
using CaptaCase.Core.Schema.CustomerSituationSchema.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaptaCase.API.Controllers
{
    [ApiController]
    [Route("api/customersituation/[controller]")]
    [ApiExplorerSettings(GroupName = "customersituation")]
    public class CustomerSituationController : ControllerBase
    {
        private readonly ILogger<CustomerSituationController> _logger;
        private readonly IMediator _mediator;

        public CustomerSituationController(ILogger<CustomerSituationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public Task<Result<CustomerSituationResponse>> Get([FromQuery] GetCustomerSituationRequest request) =>
                _mediator.Send(request);

        [HttpGet("list")]
        public Task<PaginatedResult<CustomerSituationResponse>> Get() =>
                _mediator.Send(new ListCustomerSituationRequest());

        [HttpPost()]
        public Task<Result> Post([FromBody] SaveCustomerSituationRequest request) =>
                _mediator.Send(request);

        [HttpPost("update")]
        public Task<Result> Update([FromBody] UpdateCustomerSituationRequest request) =>
                _mediator.Send(request);

        [HttpDelete()]
        public Task<Result> Delete([FromQuery] DeleteCustomerSituationRequest request) =>
                _mediator.Send(request);
    }
}