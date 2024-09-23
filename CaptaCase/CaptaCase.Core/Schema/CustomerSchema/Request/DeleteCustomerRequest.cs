using CaptaCase.Core.Schema.CustomerSchema.Response;
using MediatR;

namespace CaptaCase.Core.Schema.CustomerSchema.Request
{
    public class DeleteCustomerRequest : IRequest<Result>
    {
        public string CPF { get; set; }
    }
}
