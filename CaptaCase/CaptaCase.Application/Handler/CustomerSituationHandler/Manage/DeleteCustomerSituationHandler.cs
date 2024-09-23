using CaptaCase.Core.Schema.CustomerSituationSchema.Request;
using CaptaCase.Core.Schema;
using MediatR;
using CaptaCase.Application.Services.CustomerTypeServices.Interfaces;

namespace CaptaCase.Application.Handler.CustomerSituationHandler.Manage
{
    public class DeleteCustomerSituationHandler : IRequestHandler<DeleteCustomerSituationRequest, Result>
    {
        private readonly IManageCustomerSituationService _manageCustomerSituationService;

        public DeleteCustomerSituationHandler(IManageCustomerSituationService manageCustomerSituationService)
        {
            _manageCustomerSituationService = manageCustomerSituationService;
        }

        public async Task<Result> Handle(DeleteCustomerSituationRequest request, CancellationToken cancellationToken) =>
                        await _manageCustomerSituationService.DeleteCustomerSituation(request);
    }
}
