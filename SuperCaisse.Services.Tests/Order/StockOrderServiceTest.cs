using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;
using SuperCaisse.Services.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services.Tests.Order
{
    [TestClass]
    public class StockOrderTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();
        private StockOrderService _stockOrderService = new StockOrderService();

        // 
        [TestMethod]
        public void REQ_11_MakeStockOrderAndSendToProvider()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            Assert.IsNotNull(storekeeper);

            var articles = new List<Article>();
            articles.Add(ArticleConsts.Screwdriver);
            articles.Add(ArticleConsts.Probe);
            articles.Add(ArticleConsts.WoodenGardenChair);
            articles.Add(ArticleConsts.RJ45Cable3Meters);

            var provider = new Provider(
                "BricoWorld",
                new Details(
                    "0235353535",
                    "supply@bricoworld.com",
                    "253 ZI des quatres vents",
                    "31250",
                    "Revel"
                ),
                new Catalog()
            );

            var stockOrder = _stockOrderService.AddStockOrder(
                provider,
                storekeeper,
                articles
            );

            Assert.AreEqual(4, stockOrder.Articles.Count());
            Assert.AreEqual(97.48, stockOrder.GetPrice());
            Assert.AreEqual(OrderReportStatus.Created, stockOrder.Report.Status);

            _stockOrderService.SendStockOrder(stockOrder.Id);

            var sendStockOrder = _stockOrderService.GetStockOrder(stockOrder.Id);
            Assert.AreEqual(OrderReportStatus.Asked, sendStockOrder.Report.Status);
        }

        [TestMethod]
        public void GetPendingStockOrdersTest()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            Assert.IsNotNull(storekeeper);

            var stockOrders = _stockOrderService.GetInTransitStockOrders();
            Assert.AreEqual(2, stockOrders.Count());
        }

        [TestMethod]
        public void GetAllStockOrdersTest()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            Assert.IsNotNull(storekeeper);

            var stockOrders = _stockOrderService.GetAllStockOrders();
            Assert.AreEqual(4, stockOrders.Count());
        }
    }
}
