using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassImplementations
{
    public class Order
    {
        public Guid OrderNumber { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerFirstName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
