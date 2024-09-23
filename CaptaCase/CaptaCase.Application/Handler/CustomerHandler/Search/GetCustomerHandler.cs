using CaptaCase.Application.Services.CustomerServices.Intefaces;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerSchema.Response;
using MediatR;

namespace CaptaCase.Application.Handler.CustomerHandler.Search
{
    public class ListCustomerTypeHandler : IRequestHandler<GetCustomerRequest, Result<CustomerResponse>>
    {
        private readonly ISearchCustomerService _searchCustomerService;

        public ListCustomerTypeHandler(ISearchCustomerService searchCustomerService)
        {
            _searchCustomerService = searchCustomerService;
        }

        public async Task<Result<CustomerResponse>> Handle(GetCustomerRequest request, CancellationToken cancellationToken) =>
                        await _searchCustomerService.GetCustomer(request);
    }
}
