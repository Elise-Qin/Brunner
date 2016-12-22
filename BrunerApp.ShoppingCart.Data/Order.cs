using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunerApp.ShoppingCart.Data
{
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
