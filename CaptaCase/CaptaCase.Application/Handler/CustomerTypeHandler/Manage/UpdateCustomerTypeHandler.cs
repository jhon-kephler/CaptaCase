using CaptaCase.Core.Schema;
using MediatR;
using CaptaCase.Application.Services.CustomerSituationServices.Intefaces;
using CaptaCase.Core.Schema.CustomerTypeSchema.Request;

namespace CaptaCase.Application.Handler.CustomerTypeHandler.Manage
{
    public class UpdateCustomerTypeHandler : IRequestHandler<UpdateCustomerTypeRequest, Result>
    {
        private readonly IManageCustomerTypeService _manageCustomerTypeService;

        public UpdateCustomerTypeHandler(IManageCustomerTypeService manageCustomerTypeService)
        {
            _manageCustomerTypeService = manageCustomerTypeService;
        }

        public async Task<Result> Handle(UpdateCustomerTypeRequest request, CancellationToken cancellationToken) =>
                        await _manageCustomerTypeService.UpdateCustomerType(request);
    }
}