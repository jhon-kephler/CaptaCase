using CaptaCase.Core.Schema.CustomerSituationSchema.Request;
using CaptaCase.Core.Schema.CustomerSituationSchema.Response;
using CaptaCase.Core.Schema;
using MediatR;
using CaptaCase.Application.Services.CustomerTypeServices.Interfaces;

namespace CaptaCase.Application.Handler.CustomerSituationHandler.Search
{
    public class GetCustomerSituationHandler : IRequestHandler<GetCustomerSituationRequest, Result<CustomerSituationResponse>>
    {
        private readonly ISearchCustomerSituationService _searchCustomerSituationService;

        public GetCustomerSituationHandler(ISearchCustomerSituationService searchCustomerSituationService)
        {
            _searchCustomerSituationService = searchCustomerSituationService;
        }

        public async Task<Result<CustomerSituationResponse>> Handle(GetCustomerSituationRequest request, CancellationToken cancellationToken) =>
                        await _searchCustomerSituationService.GetCustomerSituation(request);
    }
}
