using CaptaCase.Core.Schema;
using MediatR;
using CaptaCase.Application.Services.CustomerSituationServices.Intefaces;
using CaptaCase.Core.Schema.CustomerTypeSchema.Request;

namespace CaptaCase.Application.Handler.CustomerTypeHandler.Manage
{
    public class DeleteCustomerTypeHandler : IRequestHandler<DeleteCustomerTypeRequest, Result>
    {
        private readonly IManageCustomerTypeService _manageCustomerTypeService;

        public DeleteCustomerTypeHandler(IManageCustomerTypeService manageCustomerTypeService)
        {
            _manageCustomerTypeService = manageCustomerTypeService;
        }

        public async Task<Result> Handle(DeleteCustomerTypeRequest request, CancellationToken cancellationToken) =>
                        await _manageCustomerTypeService.DeleteCustomerType(request);
    }
}