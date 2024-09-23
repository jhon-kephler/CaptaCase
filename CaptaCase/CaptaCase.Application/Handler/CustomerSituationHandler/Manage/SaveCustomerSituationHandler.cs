using CaptaCase.Core.Schema.CustomerSituationSchema.Request;
using CaptaCase.Core.Schema;
using MediatR;
using CaptaCase.Application.Services.CustomerTypeServices.Interfaces;

namespace CaptaCase.Application.Handler.CustomerSituationHandler.Manage
{
    public class SaveCustomerSituationHandler : IRequestHandler<SaveCustomerSituationRequest, Result>
    {
        private readonly IManageCustomerSituationService _manageCustomerSituationService;

        public SaveCustomerSituationHandler(IManageCustomerSituationService manageCustomerSituationService)
        {
            _manageCustomerSituationService = manageCustomerSituationService;
        }

        public async Task<Result> Handle(SaveCustomerSituationRequest request, CancellationToken cancellationToken) =>
                        await _manageCustomerSituationService.SaveCustomerSituation(request);
    }
}
