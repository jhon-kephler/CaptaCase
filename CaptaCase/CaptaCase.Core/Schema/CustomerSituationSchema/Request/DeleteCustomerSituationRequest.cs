using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Core.Schema.CustomerSituationSchema.Request
{
    public class DeleteCustomerSituationRequest : IRequest<Result>
    {
        public int SituationId { get; set; }
    }
}
