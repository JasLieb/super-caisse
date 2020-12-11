using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Services.Tests.Order
{
    [TestClass]
    public class OrderStockTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();
        private StockOrderService _orderStockService = new StockOrderService();

        [TestMethod]
        public void Scenar1()
        {
            Assert.IsTrue(
                _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy")
            );

            var articles = new List<string>();
            articles.Add("tournevis");
            articles.Add("sonde");
            articles.Add("mètre");
            articles.Add("tournevis");
            
            var stockOrder = _orderStockService.AddStockOrder(articles.ToArray());
            Assert.AreEqual(4, stockOrder.Length);
        }
    }
}
