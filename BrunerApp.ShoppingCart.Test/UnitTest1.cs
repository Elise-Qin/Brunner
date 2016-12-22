using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrunerApp.ShoppingCart.Data;

namespace BrunerApp.ShoppingCart.Test
{
    [TestClass]
    public class UnitTest1
    {
        OrderRepository orderRepo = new OrderRepository();
        [TestMethod]
        public void GetOrderListTestMethodWithData()
        {
            try
            {
                orderRepo.GetOrderList("apple,orange,apple,apple");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetOrderListTestMethodWithOutData()
        {

            orderRepo.GetOrderList(null);

        }


        [TestMethod]
        public void GenerateBillTestMethodWithData()
        {
            List<Order> orders = new List<Order> { 
            new Order(){ Product= new Product(){ Name="APPLE"}, Quantity=3},
            new Order(){ Product= new Product(){ Name="ORANGE"}, Quantity=3},
            };

            double d = orderRepo.GenerateBill(orders);
            double expectedvalue = 3.3;
            Assert.AreEqual( expectedvalue.ToString(),d.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GenerateBillTestMethodWithOutData()
        {
            List<Order> orders = null;

            double d = orderRepo.GenerateBill(orders);
           
        }
    }
}
