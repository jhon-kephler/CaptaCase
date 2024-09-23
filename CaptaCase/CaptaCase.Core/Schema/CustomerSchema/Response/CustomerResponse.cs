using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Core.Schema.CustomerSchema.Response
{
    public class CustomerResponse
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public int CustomerTypeId { get; set; }
        public string Gender { get; set; }
        public int CustomerSituationId { get; set; }
    }
}
