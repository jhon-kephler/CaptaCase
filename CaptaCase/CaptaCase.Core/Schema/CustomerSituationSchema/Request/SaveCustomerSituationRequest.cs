using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Core.Schema.CustomerSituationSchema.Request
{
    public class SaveCustomerSituationRequest : IRequest<Result>
    {
        public string Situation { get; set; }
    }
}
