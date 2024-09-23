using CaptaCase.Core.Schema.CustomerSituationSchema.Request;
using CaptaCase.Core.Schema.CustomerSituationSchema.Response;
using CaptaCase.Core.Schema;
using MediatR;
using CaptaCase.Application.Services.CustomerTypeServices.Interfaces;

namespace CaptaCase.Application.Handler.CustomerSituationHandler.Search
{
    public class ListCustomerSituationHandler : IRequestHandler<ListCustomerSituationRequest, PaginatedResult<CustomerSituationResponse>>
    {
        private readonly ISearchCustomerSituationService _searchCustomerSituationService;

        public ListCustomerSituationHandler(ISearchCustomerSituationService searchCustomerSituationService)
        {
            _searchCustomerSituationService = searchCustomerSituationService;
        }

        public async Task<PaginatedResult<CustomerSituationResponse>> Handle(ListCustomerSituationRequest request, CancellationToken cancellationToken) =>
                        await _searchCustomerSituationService.GetListCustomerSituation();
    }
}
