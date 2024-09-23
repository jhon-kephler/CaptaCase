using CaptaCase.Core.Schema.CustomerSituationSchema.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Core.Schema.CustomerSituationSchema.Request
{
    public class ListCustomerSituationRequest : IRequest<PaginatedResult<CustomerSituationResponse>>
    {
    }
}
