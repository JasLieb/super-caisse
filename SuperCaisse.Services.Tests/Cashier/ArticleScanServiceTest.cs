using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;
using System.Linq;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class ArticleScanServiceTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();
        private ArticlesService _articlesService = new ArticlesService();

        [TestMethod]
        [DataRow("0102030405")]
        [DataRow("0203040506")]
        public void REQ_4_ScanArticle_KnownArticle(string barCode)
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            var articles = _articlesService.GetArticles(barCode);
            Assert.IsTrue(articles.Count() > 0);

            var selectedArticle = articles.First();
            cashRegister.AddArticle(selectedArticle);

            Assert.AreEqual(selectedArticle.Price, cashRegister.Bracket.GetTotalPrice());
        }

        [TestMethod]
        [DataRow("-1")]
        public void REQ_4_ScanArticle_UnknownArticle(string barCode)
        {
            var articles = _articlesService.GetArticles(barCode);
            Assert.IsTrue(articles.Count() == 0);
        }

        [TestMethod]
        [DataRow("0102030405")]
        [DataRow("vis")]
        [DataRow("0203040506")]
        [DataRow("marteau")]
        public void REQ_5_ArticleWithoutBarCode_KnownArticle(string query)
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            var articles = _articlesService.Search(query);
            Assert.IsTrue(articles.Count() > 0);

            var selectedArticle = articles.First();
            cashRegister.AddArticle(selectedArticle);
            Assert.AreEqual(selectedArticle.Price, cashRegister.Bracket.GetTotalPrice());
        }

        [TestMethod]
        [DataRow("-1")]
        [DataRow("ImaginaryArticle")]
        public void REQ_5_ArticleWithoutBarCode_UnknownArticle(string query)
        {
            var articles = _articlesService.Search(query);
            Assert.IsTrue(articles.Count() == 0);
        }
    }
}
