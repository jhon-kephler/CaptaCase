using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Core.Schema.CustomerSituationSchema.Request
{
    public class UpdateCustomerSituationRequest : IRequest<Result>
    {
        public int SituationId { get; set; }
        public string Situation { get; set; }
    }
}
