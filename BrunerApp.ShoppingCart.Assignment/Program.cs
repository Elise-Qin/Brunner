using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrunerApp.ShoppingCart.Data;
using BrunerApp.ShoppingCart.Constants;
using BrunerApp.ShoppingCart.Utility;
namespace BrunerApp.ShoppingCart.Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckOut();
            Console.Read();
        }

        private static void CheckOut()
        {
            OrderRepository repo = new OrderRepository();
            IEnumerable<Order> o = repo.GetOrderList("apple,apple,apple,orange,orange,orange");
            double totalWithOffer = repo.GenerateBill(o);
            Program p = new Program();
            OfferDelegate del = new OfferDelegate(p.Offers);
            OfferRepository offerRepository = new OfferRepository();
            double totalAfterOffer = offerRepository.ApplyOffer(o, del);
            Console.WriteLine("Total = "+totalWithOffer);
            Console.WriteLine("Net Payable after Off = " + totalAfterOffer);
        }
        /// <summary>
        /// Because offers in the future can chang so I chose delegate programming over
        /// Interface programming
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public double Offers(Order order)
        {

            if (order.Product.Name == ItemName.Apple)
            {
                return ((order.Quantity / 2) + (order.Quantity % 2)) * PriceUtility.applePrice;
            }
            if (order.Product.Name == ItemName.Orange)
            {
                return ((order.Quantity / 3)*2 + (order.Quantity % 3)) * PriceUtility.orangePrice;
            }
            return 0;
        }
    }
}
