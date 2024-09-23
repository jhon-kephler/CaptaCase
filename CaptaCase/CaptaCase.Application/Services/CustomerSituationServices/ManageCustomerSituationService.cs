using AutoMapper;
using CaptaCase.Application.Services.CustomerTypeServices.Interfaces;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSituationSchema.Request;
using CaptaCase.Domain.Entities;
using CaptaCase.Domain.Repositories;

namespace CaptaCase.Application.Services.CustomerSituationServices
{
    public class ManageCustomerSituationService : IManageCustomerSituationService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerSituationRepository _customerSituationRepository;

        public ManageCustomerSituationService(IMapper mapper, ICustomerSituationRepository customerSituationRepository)
        {
            _mapper = mapper;
            _customerSituationRepository = customerSituationRepository;
        }

        public async Task<Result> SaveCustomerSituation(SaveCustomerSituationRequest request)
        {
            var result = new Result();
            try
            {
                await _customerSituationRepository.AddAsync(_mapper.Map<CustomerSituation>(request));
                result.SetCreate();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<Result> UpdateCustomerSituation(UpdateCustomerSituationRequest request)
        {
            var result = new Result();
            try
            {
                _customerSituationRepository.Update(request.SituationId, _mapper.Map<CustomerSituation>(request));
                result.SetSuccess();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<Result> DeleteCustomerSituation(DeleteCustomerSituationRequest request)
        {
            var result = new Result();
            try
            {
                _customerSituationRepository.Delete(request.SituationId);
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