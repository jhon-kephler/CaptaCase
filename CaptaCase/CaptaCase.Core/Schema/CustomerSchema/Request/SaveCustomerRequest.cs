using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Core.Schema.CustomerSchema.Request
{
    public class SaveCustomerRequest : IRequest<Result>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string TypeCustomer { get; set; }
        public string Gender { get; set; }
        public string CustomerSituation { get; set; }
    }
}
