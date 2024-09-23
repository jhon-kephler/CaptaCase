using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Core.Schema.CustomerTypeSchema.Request
{
    public class SaveCustomerTypeRequest : IRequest<Result>
    {
        public string Type { get; set; }
    }
}
