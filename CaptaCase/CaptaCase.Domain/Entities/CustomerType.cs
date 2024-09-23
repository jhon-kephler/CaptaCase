using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Domain.Entities
{
    public class CustomerType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Customer Customer { get; set; }
    }
}