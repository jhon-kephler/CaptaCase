using AutoMapper;
using CaptaCase.Application.Services.CustomerServices.Intefaces;
using CaptaCase.Core.Helper;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Domain.Entities;
using CaptaCase.Domain.Repositories;
using MediatR;

namespace CaptaCase.Application.Services.CustomerServices
{
    public class ManageCustomerService : IManageCustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerTypeRepository _customerTypeRepository;
        private readonly ICustomerSituationRepository _customerSituationRepository;

        public ManageCustomerService(IMapper mapper,
                ICustomerRepository customerRepository,
                ICustomerTypeRepository customerTypeRepository,
                ICustomerSituationRepository customerSituationRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerTypeRepository = customerTypeRepository;
            _customerSituationRepository = customerSituationRepository;
        }

        public async Task<Result> SaveCustomer(SaveCustomerRequest request)
        {
            var result = new Result();
            try
            {
                var customer = await _customerRepository.GetCustomerByCPF(request.CPF);
                if (customer != null)
                {
                    result.SetError("CPF already exists");
                    return result;
                }

                var customerType = await _customerTypeRepository.GetCustomerTypeByType(request.TypeCustomer);

                var customerSituation = await _customerSituationRepository.GetCustomerSituationeBySituation(request.CustomerSituation);

                var validation = await ValidateRequest(request.CPF.Replace(".", ""), customerType, customerSituation);
                if (!validation.IsSuccess)
                    return validation;

                customer = _mapper.Map<Customer>(request);
                customer.CustomerSituationId = customerSituation.Id;
                customer.CustomerTypeId = customerType.Id;

                await _customerRepository.AddAsync(customer);
                result.SetSuccess();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            return result;
        }

        public async Task<Result> UpdateCustomer(UpdateCustomerRequest request)
        {
            var result = new Result();
            var customerType = new CustomerType();
            var customerSituation = new CustomerSituation();
            try
            {
                var customer = await _customerRepository.GetCustomerByCPF(request.CPF);
                if (customer == null)
                {
                    result.SetError("CPF not found");
                    return result;
                }

                customer = _mapper.Map<Customer>(request);

                if (String.IsNullOrEmpty(request.TypeCustomer) || String.IsNullOrEmpty(request.Gender) || String.IsNullOrEmpty(request.Name) || String.IsNullOrEmpty(request.CustomerSituation))
                {
                    customer.CustomerSituationId = customer.CustomerSituationId;
                    customer.CustomerTypeId = customer.CustomerTypeId;
                }
                else
                {
                    customerType = await _customerTypeRepository.GetCustomerTypeByType(request.TypeCustomer);
                    customerSituation = await _customerSituationRepository.GetCustomerSituationeBySituation(request.CustomerSituation);

                    customer.CustomerSituationId = customerSituation.Id;
                    customer.CustomerTypeId = customerType.Id;
                }

                var validation = await ValidateRequest(request.CPF.Replace(".", ""), customerType, customerSituation);
                if (!validation.IsSuccess)
                    return validation;

                _customerRepository.UpdateCustomer(customer);
                result.SetCreate();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            return result;
        }

        public async Task<Result> DeleteCustomer(DeleteCustomerRequest request)
        {
            var result = new Result();
            try
            {
                _customerRepository.DeleteCustomer(request.CPF);
                result.SetSuccess();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            return result;
        }

        private async Task<Result> ValidateRequest(string cpf, CustomerType? type, CustomerSituation? situation)
        {
            var result = new Result();

            if (!DocumentHelper.IsCpf(cpf))
            {
                result.SetError("Invalid CPF");
                return result;
            }

            if (type.Id == null)
            {
                result.SetError("Invalid Type");
                return result;
            }

            if (situation.Id == null)
            {
                result.SetError("Invalid Situation");
                return result;
            }

            result.SetSuccess();
            return result;
        }
    }
}