using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema;

namespace CaptaCase.Application.Services.CustomerServices.Intefaces
{
    public interface IManageCustomerService
    {
        Task<Result> SaveCustomer(SaveCustomerRequest request);
        Task<Result> DeleteCustomer(DeleteCustomerRequest request);
        Task<Result> UpdateCustomer(UpdateCustomerRequest request);
    }
}