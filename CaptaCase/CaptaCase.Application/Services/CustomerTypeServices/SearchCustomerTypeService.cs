using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CaptaCase.Application.Services.CustomerSituationServices.Intefaces;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerTypeSchema.Request;
using CaptaCase.Core.Schema.CustomerTypeSchema.Response;
using CaptaCase.Domain.Repositories;

namespace CaptaCase.Application.Services.CustomerSituationServices
{
    public class SearchCustomerTypeService : ISearchCustomerTypeService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerTypeRepository _customerTypeRepository;

        public SearchCustomerTypeService(IMapper mapper, ICustomerTypeRepository customerTypeRepository)
        {
            _mapper = mapper;
            _customerTypeRepository = customerTypeRepository;
        }

        public async Task<Result<CustomerTypeResponse>> GetCustomerType(GetCustomerTypeRequest request)
        {
            var result = new Result<CustomerTypeResponse>();

            try
            {
                var customerType = _customerTypeRepository.GetById(request.TypeId);
                if(customerType == null)
                {
                    result.SetError("Invalid Id");
                    return result;
                }

                result.SetSuccess(_mapper.Map<CustomerTypeResponse>(customerType));
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<PaginatedResult<CustomerTypeResponse>> GetListCustomerType()
        {
            var result = new PaginatedResult<CustomerTypeResponse>();

            try
            {
                var customerType = _customerTypeRepository.GetAll();
                if (customerType == null)
                {
                    result.SetError("Invalid Id");
                    return result;
                }

                result.SetSuccess(_mapper.Map<List<CustomerTypeResponse>>(customerType));
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }
    }
}
