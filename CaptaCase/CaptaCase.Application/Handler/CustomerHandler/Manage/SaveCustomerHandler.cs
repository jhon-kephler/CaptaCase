using CaptaCase.Application.Services.CustomerServices.Intefaces;
using CaptaCase.Core.Schema;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerSchema.Response;
using MediatR;

namespace CaptaCase.Application.Handler.CustomerHandler.Manage
{
    public class SaveCustomerHandler : IRequestHandler<SaveCustomerRequest, Result>
    {
        private readonly IManageCustomerService _manageCustomerService;

        public SaveCustomerHandler(IManageCustomerService manageCustomerService)
        {
            _manageCustomerService = manageCustomerService;
        }

        public async Task<Result> Handle(SaveCustomerRequest request, CancellationToken cancellationToken) =>
                        await _manageCustomerService.SaveCustomer(request);
    }
}
