using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrunerApp.ShoppingCart.Utility;
using BrunerApp.ShoppingCart.Constants;

namespace BrunerApp.ShoppingCart.Data
{
    public delegate double OfferDelegate(Order order);
    public class OfferRepository
    {
        public double ApplyOffer(IEnumerable<Order> orderList, OfferDelegate offerDelegate)
        {

            double total = 0;
            foreach (var item in orderList)
            {
                total += offerDelegate(item);
            }

            return total;
        }


    }


}
