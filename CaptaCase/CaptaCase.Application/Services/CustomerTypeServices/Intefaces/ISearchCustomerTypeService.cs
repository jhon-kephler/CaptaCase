using CaptaCase.Core.Schema.CustomerTypeSchema.Response;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerTypeSchema.Request;

namespace CaptaCase.Application.Services.CustomerSituationServices.Intefaces
{
    public interface ISearchCustomerTypeService
    {
        Task<PaginatedResult<CustomerTypeResponse>> GetListCustomerType();
        Task<Result<CustomerTypeResponse>> GetCustomerType(GetCustomerTypeRequest request);
    }
}