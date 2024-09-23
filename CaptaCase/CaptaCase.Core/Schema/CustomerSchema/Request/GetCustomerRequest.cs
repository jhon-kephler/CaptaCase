using CaptaCase.Core.Schema.CustomerSchema.Response;
using MediatR;

namespace CaptaCase.Core.Schema.CustomerSchema.Request
{
    public class GetCustomerRequest : IRequest<Result<CustomerResponse>>
    {
        public string CPF { get; set; }
    }
}
