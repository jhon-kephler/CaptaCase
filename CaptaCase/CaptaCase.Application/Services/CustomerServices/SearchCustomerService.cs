using CaptaCase.Application.Services.CustomerServices.Intefaces;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerSchema.Response;
using CaptaCase.Core.Schema;
using AutoMapper;
using CaptaCase.Domain.Repositories;
using MediatR;

namespace CaptaCase.Application.Services.CustomerServices
{
    public class SearchCustomerService : ISearchCustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public SearchCustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Result<CustomerResponse>> GetCustomer(GetCustomerRequest request)
        {
            var result = new Result<CustomerResponse>();

            try
            {
                var customer = await _customerRepository.GetCustomerByCPF(request.CPF);
                if(customer == null)
                {
                    result.SetError("Invalid CPF");
                    return result;
                }

                result.SetSuccess(_mapper.Map<CustomerResponse>(customer));
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<PaginatedResult<CustomerResponse>> GetListCustomer()
        {
            var result = new PaginatedResult<CustomerResponse>();
            try
            {
                var customer = _customerRepository.GetAll();

                result = new PaginatedResult<CustomerResponse>(_mapper.Map<List<CustomerResponse>>(customer));
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            return result;
        }
    }
}
