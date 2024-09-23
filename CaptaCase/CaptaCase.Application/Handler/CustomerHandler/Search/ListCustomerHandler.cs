using CaptaCase.Application.Services.CustomerServices.Intefaces;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerSchema.Response;
using MediatR;

namespace CaptaCase.Application.Handler.CustomerHandler
{
    public class ListCustomerHandler : IRequestHandler<ListCustomerRequest, PaginatedResult<CustomerResponse>>
    {
        private readonly ISearchCustomerService _searchCustomerService;

        public ListCustomerHandler(ISearchCustomerService searchCustomerService)
        {
            _searchCustomerService = searchCustomerService;
        }

        public async Task<PaginatedResult<CustomerResponse>> Handle(ListCustomerRequest request, CancellationToken cancellationToken) =>
                        await _searchCustomerService.GetListCustomer();
    }
}
