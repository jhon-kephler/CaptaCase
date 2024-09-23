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

namespace CaptaCase.Application.Handler.CustomerTypeHandler.Search
{
    public class ListCustomerTypeHandler : IRequestHandler<ListCustomerTypeRequest, PaginatedResult<CustomerTypeResponse>>
    {
        private readonly ISearchCustomerTypeService _searchCustomerTypeService;

        public ListCustomerTypeHandler(ISearchCustomerTypeService searchCustomerTypeService)
        {
            _searchCustomerTypeService = searchCustomerTypeService;
        }

        public async Task<PaginatedResult<CustomerTypeResponse>> Handle(ListCustomerTypeRequest request, CancellationToken cancellationToken) =>
                        await _searchCustomerTypeService.GetListCustomerType();
    }
}