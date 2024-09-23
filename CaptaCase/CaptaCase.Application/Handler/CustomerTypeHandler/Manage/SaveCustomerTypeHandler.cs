using CaptaCase.Application.Services.CustomerServices.Intefaces;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerSchema.Response;
using CaptaCase.Core.Schema;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaptaCase.Application.Services.CustomerSituationServices.Intefaces;
using CaptaCase.Core.Schema.CustomerTypeSchema.Response;
using CaptaCase.Core.Schema.CustomerTypeSchema.Request;

namespace CaptaCase.Application.Handler.CustomerTypeHandler.Manage
{
    public class SaveCustomerTypeHandler : IRequestHandler<SaveCustomerTypeRequest, Result>
    {
        private readonly IManageCustomerTypeService _manageCustomerTypeService;

        public SaveCustomerTypeHandler(IManageCustomerTypeService manageCustomerTypeService)
        {
            _manageCustomerTypeService = manageCustomerTypeService;
        }

        public async Task<Result> Handle(SaveCustomerTypeRequest request, CancellationToken cancellationToken) =>
                        await _manageCustomerTypeService.SaveCustomerType(request);
    }
}