using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Concrete
{
   public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public IList<Product> Products { get; set; }
        public int OrderAmount { get; set; }
    }
}
