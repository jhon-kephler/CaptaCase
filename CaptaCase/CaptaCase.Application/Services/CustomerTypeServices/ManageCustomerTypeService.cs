using AutoMapper;
using CaptaCase.Application.Services.CustomerSituationServices.Intefaces;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerTypeSchema.Request;
using CaptaCase.Domain.Entities;
using CaptaCase.Domain.Repositories;

namespace CaptaCase.Application.Services.CustomerSituationServices
{
    public class ManageCustomerTypeService : IManageCustomerTypeService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerTypeRepository _customerTypeRepository;

        public ManageCustomerTypeService(IMapper mapper, ICustomerTypeRepository customerTypeRepository)
        {
            _mapper = mapper;
            _customerTypeRepository = customerTypeRepository;
        }

        public async Task<Result> SaveCustomerType(SaveCustomerTypeRequest request)
        {
            var result = new Result();
            try
            {
                await _customerTypeRepository.AddAsync(_mapper.Map<CustomerType>(request));
                result.SetCreate();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<Result> UpdateCustomerType(UpdateCustomerTypeRequest request)
        {
            var result = new Result();
            try
            {
                _customerTypeRepository.Update(request.TypeId, _mapper.Map<CustomerType>(request));
                result.SetSuccess();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<Result> DeleteCustomerType(DeleteCustomerTypeRequest request)
        {
            var result = new Result();
            try
            {
                _customerTypeRepository.Delete(request.TypeId);
                result.SetSuccess();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }
    }
}