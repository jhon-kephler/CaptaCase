using CaptaCase.Core.Schema.CustomerSituationSchema.Request;
using CaptaCase.Core.Schema;
using MediatR;
using CaptaCase.Application.Services.CustomerTypeServices.Interfaces;

namespace CaptaCase.Application.Handler.CustomerSituationHandler.Manage
{
    public class UpdateCustomerSituationHandler : IRequestHandler<UpdateCustomerSituationRequest, Result>
    {
        private readonly IManageCustomerSituationService _manageCustomerSituationService;

        public UpdateCustomerSituationHandler(IManageCustomerSituationService manageCustomerSituationService)
        {
            _manageCustomerSituationService = manageCustomerSituationService;
        }

        public async Task<Result> Handle(UpdateCustomerSituationRequest request, CancellationToken cancellationToken) =>
                        await _manageCustomerSituationService.UpdateCustomerSituation(request);
    }
}
