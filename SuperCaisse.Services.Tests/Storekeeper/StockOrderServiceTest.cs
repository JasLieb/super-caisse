using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;
using System.Collections.Generic;
using System.Linq;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class StockOrderTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();
        private ProviderService _providerService = new ProviderService();
        private StockOrderService _stockOrderService = new StockOrderService();

        [TestMethod]
        public void REQ_10_GetInTransitStockOrders()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            Assert.IsNotNull(storekeeper);

            var stockOrders = _stockOrderService.GetInTransitStockOrders();
            Assert.IsTrue(stockOrders.Count() > 0);
        }

        [TestMethod]
        public void REQ_10_GetAllStockOrders()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            Assert.IsNotNull(storekeeper);

            var stockOrders = _stockOrderService.GetAllStockOrders();
            Assert.IsTrue(stockOrders.Count() > 0);
        }

        [TestMethod]
        public void REQ_12_MakeStockOrderAndSendToProvider()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            Assert.IsNotNull(storekeeper);

            var stockOrder = MakeStockOrder(storekeeper);
            Assert.AreEqual(4, stockOrder.Articles.Count());
            Assert.AreEqual(97.48, stockOrder.GetPrice());
            Assert.AreEqual(OrderReportStatus.Created, stockOrder.Report.Status);

            _stockOrderService.SendStockOrder(stockOrder.Id);

            var sendStockOrder = _stockOrderService.GetStockOrder(stockOrder.Id);
            Assert.AreEqual(OrderReportStatus.Asked, sendStockOrder.Report.Status);
        }

        private StockOrder MakeStockOrder(Storekeeper storekeeper)
        {
            var provider = _providerService.GetProvider("BricoWorld");

            var articles = new List<Article>();
            articles.Add(ArticleConsts.Screwdriver);
            articles.Add(ArticleConsts.Probe);
            articles.Add(ArticleConsts.WoodenGardenChair);
            articles.Add(ArticleConsts.RJ45Cable3Meters);

            var stockOrder = _stockOrderService.AddStockOrder(
                provider,
                storekeeper,
                articles
            );
            return stockOrder;
        }

        [TestMethod]
        public void REQ_14_ReceiptAnOrder()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            Assert.IsNotNull(storekeeper);

            var orderInTransit = MakeStockOrder(storekeeper);
            _stockOrderService.SendStockOrder(orderInTransit.Id);

            var orderReceived = _stockOrderService.GetStockOrder(orderInTransit.Id);
            _stockOrderService.RecieveOrder(
                orderReceived.Id,
                5,
                string.Empty,
                string.Empty
            );
        }
    }
}
