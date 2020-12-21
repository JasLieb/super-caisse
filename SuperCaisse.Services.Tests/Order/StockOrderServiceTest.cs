using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Services.Tests.Order
{
    [TestClass]
    public class StockOrderTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();
        private StockOrderService _orderStockService = new StockOrderService();

        [TestMethod]
        public void Scenar1()
        {
            Assert.IsTrue(
                _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy")
            );

            var articles = new List<Article>();
            articles.Add(new Article() { 
                BarCode = "01010",
                Category = Categories.Tools,
                Name = "Tournevis",
                Price = 14.99
            });
            articles.Add(new Article()
            {
                BarCode = "10101",
                Category = Categories.Tools,
                Name = "Sonde",
                Price = 49.99
            });
            articles.Add(new Article()
            {
                BarCode = "11111",
                Category = Categories.Garden,
                Name = "Chaise en bois de jardin",
                Price = 25
            });
            articles.Add(new Article()
            {
                BarCode = "11001",
                Category = Categories.Electronic,
                Name = "Cable RJ45 3m",
                Price = 7.50
            });
            
            var stockOrder = _orderStockService.AddStockOrder(articles.ToArray());
            Assert.AreEqual(4, stockOrder.articles.Length);
            Assert.AreEqual(97.48, stockOrder.totalPrice);
        }
    }
}
