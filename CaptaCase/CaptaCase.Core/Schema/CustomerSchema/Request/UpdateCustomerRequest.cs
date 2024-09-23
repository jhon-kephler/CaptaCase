using MediatR;

namespace CaptaCase.Core.Schema.CustomerSchema.Request
{
    public class UpdateCustomerRequest : IRequest<Result>
    {
        public string? Name { get; set; }
        public string CPF { get; set; }
        public string? TypeCustomer { get; set; }
        public string? Gender { get; set; }
        public string? CustomerSituation { get; set; }
    }
}
