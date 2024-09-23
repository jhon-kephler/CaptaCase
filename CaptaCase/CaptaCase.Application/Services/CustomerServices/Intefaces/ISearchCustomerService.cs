using CaptaCase.Core.Schema.CustomerSchema.Response;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSchema.Request;

namespace CaptaCase.Application.Services.CustomerServices.Intefaces
{
    public interface ISearchCustomerService
    {
        Task<PaginatedResult<CustomerResponse>> GetListCustomer();
        Task<Result<CustomerResponse>> GetCustomer(GetCustomerRequest request);
    }
}