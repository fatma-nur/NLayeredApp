using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Concrete
{
    public class Stock
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
        public IList<Product> Products { get; set; }
        public int StockAmount { get; set; }
    }
}
