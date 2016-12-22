using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace BrunerApp.ShoppingCart.Utility
{
    public static class PriceUtility
    {
       public static double applePrice = Convert.ToDouble(ConfigurationManager.AppSettings["apple"]);
       public static double orangePrice = Convert.ToDouble(ConfigurationManager.AppSettings["orange"]);
    }
}
