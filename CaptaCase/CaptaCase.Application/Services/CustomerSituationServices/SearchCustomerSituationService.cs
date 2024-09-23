using AutoMapper;
using CaptaCase.Application.Services.CustomerTypeServices.Interfaces;
using CaptaCase.Core.Schema;
using CaptaCase.Domain.Repositories;
using CaptaCase.Core.Schema.CustomerSituationSchema.Response;
using CaptaCase.Core.Schema.CustomerSituationSchema.Request;

namespace CaptaCase.Application.Services.CustomerTypeServices
{
    public class SearchCustomerSituationService : ISearchCustomerSituationService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerSituationRepository _customerSituationRepository;

        public SearchCustomerSituationService(IMapper mapper, ICustomerSituationRepository customerSituationRepository)
        {
            _mapper = mapper;
            _customerSituationRepository = customerSituationRepository;
        }

        public async Task<Result<CustomerSituationResponse>> GetCustomerSituation(GetCustomerSituationRequest request)
        {
            var result = new Result<CustomerSituationResponse>();

            try
            {
                var customerSituation = _customerSituationRepository.GetById(request.SituationId);
                if (customerSituation == null)
                {
                    result.SetError("Invalid Id");
                    return result;
                }

                result.SetSuccess(_mapper.Map<CustomerSituationResponse>(customerSituation));
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<PaginatedResult<CustomerSituationResponse>> GetListCustomerSituation()
        {
            var result = new PaginatedResult<CustomerSituationResponse>();

            try
            {
                var customerSituation = _customerSituationRepository.GetAll();
                if (customerSituation == null)
                {
                    result.SetError("Invalid Id");
                    return result;
                }

                result.SetSuccess(_mapper.Map<List<CustomerSituationResponse>>(customerSituation));
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }
    }
}