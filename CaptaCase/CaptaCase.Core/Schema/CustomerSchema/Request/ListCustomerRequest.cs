using CaptaCase.Core.Schema.CustomerSchema.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Core.Schema.CustomerSchema.Request
{
    public class ListCustomerRequest : IRequest<PaginatedResult<CustomerResponse>>
    {
    }
}
