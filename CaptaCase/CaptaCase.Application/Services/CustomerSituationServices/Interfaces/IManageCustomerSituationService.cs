using CaptaCase.Core.Schema.CustomerSituationSchema.Request;
using CaptaCase.Core.Schema;

namespace CaptaCase.Application.Services.CustomerTypeServices.Interfaces
{
    public interface IManageCustomerSituationService
    {
        Task<Result> SaveCustomerSituation(SaveCustomerSituationRequest request);
        Task<Result> UpdateCustomerSituation(UpdateCustomerSituationRequest request);
        Task<Result> DeleteCustomerSituation(DeleteCustomerSituationRequest request);
    }
}