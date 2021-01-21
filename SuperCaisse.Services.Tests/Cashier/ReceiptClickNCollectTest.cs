using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class ReceiptClickNCollectTest
    {
        private WebAuthentificationService _webAuthentificationService = new WebAuthentificationService();
        private ArticlesService _articlesService = new ArticlesService();
        private ShopInfosService _shopInfosService = new ShopInfosService();
        private AuthentificationService _authentificationService = new AuthentificationService();

        [TestMethod]
        public void REQ_18_ReceiptClickNCollectOrder_InToulouseShop_AlreadyPaid()
        {
            // This method return the shop used from the web part 
            // In the future the Shop must be itself initilazed with DB data loading mechanism
            // In fact, for the exercise, this last element is ignored
            var shop = MakeClickNCollectOrderAlreadyPaid();

            Thread.Sleep(1000); // Some time later

            var webOrder = shop.ClickNCollectService.FindWebOrders("Already").First();

            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            cashRegister.ReceiptWebOrder(webOrder);
            Assert.IsTrue(cashRegister.CanCompleteTransaction);
            
            cashRegister.CompleteTransaction();
            Assert.IsNull(cashRegister.Bracket);
            Assert.IsNull(cashRegister.WebOrder);
        }

        [TestMethod]
        public void REQ_18_ReceiptClickNCollectOrder_InToulouseShop_NotAlreadyPaid()
        {
            // This method return the shop used from the web part 
            // In the future the Shop must be itself initilazed with DB data loading mechanism
            // In fact, for the exercise, this last element is ignored
            var shop = MakeClickNCollectOrderNotAlreadyPaid();

            Thread.Sleep(1000); // Some time later

            var webOrder = shop.ClickNCollectService.FindWebOrders("Already").First();

            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            cashRegister.ReceiptWebOrder(webOrder);
            Assert.IsFalse(cashRegister.CanCompleteTransaction);

            cashRegister.PayWithCheck(webOrder.Bracket.GetTotalPrice());
            Assert.IsTrue(cashRegister.CanCompleteTransaction);

            cashRegister.CompleteTransaction();
            Assert.IsNull(cashRegister.Bracket);
            Assert.IsNull(cashRegister.WebOrder);
        }

        private Shop MakeClickNCollectOrderAlreadyPaid()
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
            var availablesShops = _shopInfosService.GetShops();
            Assert.AreEqual(2, availablesShops.Count());

            var selectedShop = availablesShops.First(
                shop => shop.Address.City == "Toulouse"
            );

            webSession.SetClickNCollectDeliveryMode(selectedShop.Id);

            webSession.PayWtihBC(
                "4545-5555-5555-5555",
                "01/25",
                "111"
            );
            webSession.CompleteTransaction();

            return webSession.GetSelectedShop();
        }

        private Shop MakeClickNCollectOrderNotAlreadyPaid()
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
            var availablesShops = _shopInfosService.GetShops();
            Assert.AreEqual(2, availablesShops.Count());

            var selectedShop = availablesShops.First(
                shop => shop.Address.City == "Toulouse"
            );

            webSession.SetClickCollectPaymentInShopDeliveryMode(selectedShop.Id);

            webSession.CompleteTransaction();

            return webSession.GetSelectedShop();
        }
    }
}
