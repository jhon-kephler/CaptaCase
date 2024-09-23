using CaptaCase.Core.Schema.CustomerTypeSchema.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Core.Schema.CustomerTypeSchema.Request
{
    public class GetCustomerTypeRequest : IRequest<Result<CustomerTypeResponse>>
    {
        public int TypeId { get; set; }
    }
}
