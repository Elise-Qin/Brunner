using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrunerApp.ShoppingCart.Utility;
using BrunerApp.ShoppingCart.Constants;
namespace BrunerApp.ShoppingCart.Data
{

    public class OrderRepository
    {

        public IEnumerable<Order> GetOrderList(string itemsname)
        {
            if (string.IsNullOrEmpty(itemsname))
            {
                throw new NullReferenceException();
            }
            string[] items = itemsname.ToUpper().Split(',');
            List<Order> ordertList = new List<Order>();
            var orderDetail = items.GroupBy(x => x).Select(x => new { Name = x.Key, Qty = x.Count() });

            foreach (var item in orderDetail)
            {
                ordertList.Add(new Order() { Product = new Product() { Name = item.Name }, Quantity = item.Qty });
            }

            return ordertList.AsEnumerable();
        }

        public double GenerateBill(IEnumerable<Order> ordertList)
        {
            if (ordertList == null)
            {
                throw new NullReferenceException();
            }

            double total = 0;
            foreach (var item in ordertList)
            {
                if (item.Product.Name == ItemName.Apple)
                {
                    total += (item.Quantity * PriceUtility.applePrice);
                }
                if (item.Product.Name == ItemName.Orange)
                {
                    total += (item.Quantity * PriceUtility.orangePrice);
                }
            }
            return total;
        }


    }
}
