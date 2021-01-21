using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class WebSessionTest
    {
        private WebAuthentificationService _webAuthentificationService = new WebAuthentificationService();
        private ArticlesService _articlesService = new ArticlesService();
        private ShopInfosService _shopsService = new ShopInfosService();

        [TestMethod]
        public void REQ_15_MakeOnlineBracket_WithoutConnection()
        {
            var webSession = new WebSession();
            var articleBarCode = "0102030405";
            var article = _articlesService.GetArticles(articleBarCode).First();

            webSession.AddArticle(article);
            Assert.AreEqual(article.Price, webSession.Bracket.GetTotalPrice());
            Assert.IsFalse(webSession.CanFinalizeOrder);
        }

        [TestMethod]
        public void REQ_15_MakeOnlineBracket_WithConnection_WithDelieveryModeAtHome()
        {
            var webSession = MakeWebConnectedSession();
            
            var selectedArticleBarCode = "0102030405";
            var selectedArticle = _articlesService.GetArticles(selectedArticleBarCode).First();
            Assert.AreEqual(selectedArticle.Price, webSession.Bracket.GetTotalPrice());
            Assert.IsTrue(webSession.CanFinalizeOrder);
        }

        [TestMethod]
        public void REQ_17_FinalizeOnlineBracket_WithDelieveryModeAtHome()
        {
            var webSession = MakeWebConnectedSession();

            webSession.SetAtHomeDeliveryMode();
            Assert.AreEqual(DeliveryMode.AtHome, webSession.SelectedDeliveryMode);
            Assert.IsTrue(
                webSession.PayWtihBC(
                    "4545-5555-5555-5555", 
                    "01/25", 
                    "111"
                )
            );
            Assert.IsTrue(webSession.CanCompleteTransaction);
            webSession.CompleteTransaction();
        }

        [TestMethod]
        public void REQ_17_FinalizeOnlineBracket_WithDelieveryModeClickNCollect()
        {
            WebSession webSession = MakeWebConnectedSession();

            var availablesShops = _shopsService.GetShops();
            Assert.AreEqual(2, availablesShops.Count());

            var selectedShop = availablesShops.First(
                shop => shop.Address.City == "Balma"
            );

            webSession.SetClickNCollectDeliveryMode(selectedShop.Id);
            Assert.AreEqual(DeliveryMode.ClickCollect, webSession.SelectedDeliveryMode);
            Assert.AreEqual(DeliveryMode.ClickCollect, webSession.SelectedDeliveryMode);
            Assert.AreEqual(selectedShop.Id, webSession.GetSelectedShop().Id);
            Assert.IsFalse(webSession.CanCompleteTransaction);
            Assert.IsTrue(
                webSession.PayWtihBC(
                    "4545-5555-5555-5555",
                    "01/25",
                    "111"
                )
            );

            Assert.IsTrue(webSession.CanCompleteTransaction);
            webSession.CompleteTransaction();
            var orders = webSession.GetSelectedShop().Proxy.GetClickAndCollectOrder();
            Assert.AreEqual(1, orders.Count());
        }

        [TestMethod]
        public void REQ_17_FinalizeOnlineBracket_WithDelieveryModeClickCollectPaymentInShop()
        {
            var webSession = MakeWebConnectedSession();

            var availablesShops = _shopsService.GetShops();
            Assert.AreEqual(2, availablesShops.Count());

            var selectedShop = availablesShops.First(
                shop => shop.Address.City == "Toulouse"
            );

            webSession.SetClickCollectPaymentInShopDeliveryMode(selectedShop.Id);

            Assert.AreEqual(DeliveryMode.ClickCollectPaymentInShop, webSession.SelectedDeliveryMode);
            Assert.AreEqual(selectedShop.Id, webSession.GetSelectedShop().Id);
            Assert.IsTrue(webSession.CanCompleteTransaction);
            
            webSession.CompleteTransaction();

            var orders = webSession.GetSelectedShop().Proxy.GetClickAndCollectOrder();
            Assert.AreEqual(1, orders.Count());
        }

        private WebSession MakeWebConnectedSession()
        {
            var webSession = new WebSession();
            var customer = _webAuthentificationService.ConnectCustomer(
                "already@registered.com",
                "notfunnypassword"
            );
            webSession.ConnectCustomer(customer);

            var articleBarCode = "0102030405";
            var article = _articlesService.GetArticles(articleBarCode).First();

            webSession.AddArticle(article);
            return webSession;
        }
    }
}
