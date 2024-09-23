using CaptaCase.Core.Schema.CustomerTypeSchema.Request;
using CaptaCase.Core.Schema;

namespace CaptaCase.Application.Services.CustomerSituationServices.Intefaces
{
    public interface IManageCustomerTypeService
    {
        Task<Result> SaveCustomerType(SaveCustomerTypeRequest request);
        Task<Result> UpdateCustomerType(UpdateCustomerTypeRequest request);
        Task<Result> DeleteCustomerType(DeleteCustomerTypeRequest request);
    }
}