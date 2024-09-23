using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Domain.Entities
{
    public class Customer
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public int CustomerTypeId { get; set; }
        public string Gender { get; set; }
        public int CustomerSituationId { get; set; }

        public CustomerType CustomerType { get; set; }
        public CustomerSituation CustomerSituation { get; set; }
    }
}
