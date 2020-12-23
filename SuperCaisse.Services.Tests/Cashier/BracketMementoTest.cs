using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class BracketMementoTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();
        private ArticlesService _articlesService = new ArticlesService();
        private BracketMementoService _mementoService = new BracketMementoService();

        [TestMethod]
        public void REQ_6_MakeBracketAsMemento()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            Assert.IsNotNull(cashier);

            var cashRegister = new CashRegister(cashier);

            var articles = _articlesService.GetArticles("0102030405");
            Assert.IsTrue(articles.Count() > 0);

            var selectedArticle = articles.First();
            cashRegister.AddArticle(selectedArticle);

            var bracketMemento = cashRegister.MakeBracketMemento();
            _mementoService.SaveBracket(bracketMemento);
            var savedBracket = _mementoService.GetSavedBracket(bracketMemento.Id);

            Assert.AreEqual(0, _mementoService.SavedBrackets.Count());
            Assert.AreEqual(1, savedBracket.Articles.Count());
            Assert.AreEqual(selectedArticle.Price, savedBracket.GetTotalPrice());
        }

        [TestMethod]
        public void REQ_6_ResumeBracketMemento()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            Assert.IsNotNull(cashier);

            var cashRegister = new CashRegister(cashier);

            var articles = _articlesService.GetArticles("0102030405");
            Assert.IsTrue(articles.Count() > 0);

            var selectedArticle = articles.First();
            cashRegister.AddArticle(selectedArticle);

            var bracketMemento = cashRegister.MakeBracketMemento();
            _mementoService.SaveBracket(bracketMemento);
            Assert.IsNull(cashRegister.Bracket);

            var savedBracket = _mementoService.GetSavedBracket(bracketMemento.Id);
            Assert.AreEqual(0, _mementoService.SavedBrackets.Count());

            cashRegister.RestoreBracket(savedBracket);
            Assert.AreEqual(1, cashRegister.Bracket.Articles.Count());
            Assert.AreEqual(selectedArticle.Price, cashRegister.Bracket.GetTotalPrice());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void REQ_6_ResumeMementoWithNoEmptyBracket()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            Assert.IsNotNull(cashier);

            var cashRegister = new CashRegister(cashier);

            var selectedArticle = _articlesService.GetArticles("0102030405").First();
            cashRegister.AddArticle(selectedArticle);

            var bracketMemento = cashRegister.MakeBracketMemento();
            _mementoService.SaveBracket(bracketMemento);         
            cashRegister.AddArticle(selectedArticle);

            var savedBracket = _mementoService.GetSavedBracket(bracketMemento.Id);
            cashRegister.RestoreBracket(savedBracket);
        }
    }
}
