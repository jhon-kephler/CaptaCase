using CaptaCase.Core.Schema.CustomerSituationSchema.Response;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSituationSchema.Request;

namespace CaptaCase.Application.Services.CustomerTypeServices.Interfaces
{
    public interface ISearchCustomerSituationService
    {
        Task<PaginatedResult<CustomerSituationResponse>> GetListCustomerSituation();
        Task<Result<CustomerSituationResponse>> GetCustomerSituation(GetCustomerSituationRequest request);
    }
}