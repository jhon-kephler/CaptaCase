using CaptaCase.Application.Services.CustomerServices.Intefaces;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerSchema.Response;
using MediatR;

namespace CaptaCase.Application.Handler.CustomerHandler.Manage
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, Result>
    {
        private readonly IManageCustomerService _manageCustomerService;

        public UpdateCustomerHandler(IManageCustomerService manageCustomerService)
        {
            _manageCustomerService = manageCustomerService;
        }

        public async Task<Result> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken) =>
                        await _manageCustomerService.UpdateCustomer(request);
    }
}
