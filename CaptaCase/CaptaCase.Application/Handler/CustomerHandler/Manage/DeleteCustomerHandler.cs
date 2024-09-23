using CaptaCase.Application.Services.CustomerServices.Intefaces;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerSchema.Response;
using MediatR;

namespace CaptaCase.Application.Handler.CustomerHandler.Manage
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, Result>
    {
        private readonly IManageCustomerService _manageCustomerService;

        public DeleteCustomerHandler(IManageCustomerService manageCustomerService)
        {
            _manageCustomerService = manageCustomerService;
        }

        public async Task<Result> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken) =>
                        await _manageCustomerService.DeleteCustomer(request);
    }
}