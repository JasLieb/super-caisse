using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class BracketPayementTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();
        private ArticlesService _articlesService = new ArticlesService();

        [TestMethod]
        public void REQ_7_PayBillWithCash()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            var firstSelectedArticle = _articlesService.GetArticles("0102030405").First();
            cashRegister.AddArticle(firstSelectedArticle);

            var secondSelectedArticle = _articlesService.GetArticles("0203040506").First();
            cashRegister.AddArticle(secondSelectedArticle);

            var bracketTotalPrice = firstSelectedArticle.Price + secondSelectedArticle.Price;
            //Assert.AreEqual(bracketTotalPrice, cashRegister.GetRemainsDependent());
            
            cashRegister.PayWithCash(50);
            Assert.IsFalse(cashRegister.CanCompleteTransaction);

            Assert.AreEqual(bracketTotalPrice - 50, cashRegister.GetRemainsDependent());
            cashRegister.GiveBackChange(40.5);
            
            Assert.IsTrue(cashRegister.CanCompleteTransaction);
            Assert.AreEqual(0, cashRegister.GetRemainsDependent());
            Assert.AreEqual(2, cashRegister.Bracket.Transactions.Count());
            
            var firstTransaction = cashRegister.Bracket.Transactions.ElementAt(0);
            Assert.AreEqual(50, firstTransaction.Amount);
            Assert.AreEqual(TransactionType.Cash, firstTransaction.Type);

            var secondTransaction = cashRegister.Bracket.Transactions.ElementAt(1);
            Assert.AreEqual(40.5, secondTransaction.Amount);
            Assert.AreEqual(TransactionType.CashChange, secondTransaction.Type);


            cashRegister.CompleteTransaction();
            Assert.IsNull(cashRegister.Bracket);
            Assert.IsNull(cashRegister.WebOrder);
        }

        [TestMethod]
        public void REQ_7_PayBillWithBC()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            var firstSelectedArticle = _articlesService.GetArticles("0102030405").First();
            cashRegister.AddArticle(firstSelectedArticle);

            var secondSelectedArticle = _articlesService.GetArticles("0203040506").First();
            cashRegister.AddArticle(secondSelectedArticle);

            var bracketTotalPrice = firstSelectedArticle.Price + secondSelectedArticle.Price;
            Assert.AreEqual(bracketTotalPrice, cashRegister.GetRemainsDependent());

            cashRegister.PayWithBC(bracketTotalPrice);
            Assert.IsTrue(cashRegister.CanCompleteTransaction);
            Assert.AreEqual(0, cashRegister.GetRemainsDependent());
            Assert.AreEqual(1, cashRegister.Bracket.Transactions.Count());

            var firstTransaction = cashRegister.Bracket.Transactions.ElementAt(0);
            Assert.AreEqual(bracketTotalPrice, firstTransaction.Amount);
            Assert.AreEqual(TransactionType.BC, firstTransaction.Type);

            cashRegister.CompleteTransaction();
            Assert.IsNull(cashRegister.Bracket);
            Assert.IsNull(cashRegister.WebOrder);
        }

        [TestMethod]
        public void REQ_7_PayBillWithCheck()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            var firstSelectedArticle = _articlesService.GetArticles("0102030405").First();
            cashRegister.AddArticle(firstSelectedArticle);

            var secondSelectedArticle = _articlesService.GetArticles("0203040506").First();
            cashRegister.AddArticle(secondSelectedArticle);

            var bracketTotalPrice = firstSelectedArticle.Price + secondSelectedArticle.Price;
            Assert.AreEqual(bracketTotalPrice, cashRegister.GetRemainsDependent());

            cashRegister.PayWithCheck(bracketTotalPrice);
            Assert.IsTrue(cashRegister.CanCompleteTransaction);
            Assert.AreEqual(0, cashRegister.GetRemainsDependent());
            Assert.AreEqual(1, cashRegister.Bracket.Transactions.Count());

            var firstTransaction = cashRegister.Bracket.Transactions.ElementAt(0);
            Assert.AreEqual(bracketTotalPrice, firstTransaction.Amount);
            Assert.AreEqual(TransactionType.Check, firstTransaction.Type);

            cashRegister.CompleteTransaction();
            Assert.IsNull(cashRegister.Bracket);
            Assert.IsNull(cashRegister.WebOrder);
        }

        [TestMethod]
        public void REQ_7_PayBillWithCashAndCheck()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            var firstSelectedArticle = _articlesService.GetArticles("0102030405").First();
            cashRegister.AddArticle(firstSelectedArticle);

            var secondSelectedArticle = _articlesService.GetArticles("0203040506").First();
            cashRegister.AddArticle(secondSelectedArticle);

            var bracketTotalPrice = firstSelectedArticle.Price + secondSelectedArticle.Price;
            Assert.AreEqual(bracketTotalPrice, cashRegister.GetRemainsDependent());
            
            double cashAmount = 2;
            double checkAmount = 7.5;
            
            cashRegister.PayWithCash(cashAmount);
            Assert.IsFalse(cashRegister.CanCompleteTransaction);
            Assert.AreEqual(bracketTotalPrice - cashAmount, cashRegister.GetRemainsDependent());

            cashRegister.PayWithCheck(checkAmount);
            Assert.IsTrue(cashRegister.CanCompleteTransaction);
            Assert.AreEqual(0, cashRegister.GetRemainsDependent());
            Assert.AreEqual(2, cashRegister.Bracket.Transactions.Count());

            var firstTransaction = cashRegister.Bracket.Transactions.ElementAt(0);
            Assert.AreEqual(cashAmount, firstTransaction.Amount);
            Assert.AreEqual(TransactionType.Cash, firstTransaction.Type);

            var secondTransaction = cashRegister.Bracket.Transactions.ElementAt(1);
            Assert.AreEqual(checkAmount, secondTransaction.Amount);
            Assert.AreEqual(TransactionType.Check, secondTransaction.Type);

            cashRegister.CompleteTransaction();
            Assert.IsNull(cashRegister.Bracket);
            Assert.IsNull(cashRegister.WebOrder);
        }

        [TestMethod]
        public void REQ_7_PayBillWithCashAndBC()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            var firstSelectedArticle = _articlesService.GetArticles("0102030405").First();
            cashRegister.AddArticle(firstSelectedArticle);

            var secondSelectedArticle = _articlesService.GetArticles("0203040506").First();
            cashRegister.AddArticle(secondSelectedArticle);

            var bracketTotalPrice = firstSelectedArticle.Price + secondSelectedArticle.Price;
            Assert.AreEqual(bracketTotalPrice, cashRegister.GetRemainsDependent());

            double cashAmount = 2;
            double bcAmount = 7.5;

            cashRegister.PayWithCash(cashAmount);
            Assert.IsFalse(cashRegister.CanCompleteTransaction);
            Assert.AreEqual(bracketTotalPrice - cashAmount, cashRegister.GetRemainsDependent());

            cashRegister.PayWithBC(bcAmount);
            Assert.IsTrue(cashRegister.CanCompleteTransaction);
            Assert.AreEqual(0, cashRegister.GetRemainsDependent());

            Assert.AreEqual(2, cashRegister.Bracket.Transactions.Count());

            var firstTransaction = cashRegister.Bracket.Transactions.ElementAt(0);
            Assert.AreEqual(cashAmount, firstTransaction.Amount);
            Assert.AreEqual(TransactionType.Cash, firstTransaction.Type);

            var secondTransaction = cashRegister.Bracket.Transactions.ElementAt(1);
            Assert.AreEqual(bcAmount, secondTransaction.Amount);
            Assert.AreEqual(TransactionType.BC, secondTransaction.Type);

            cashRegister.CompleteTransaction();
            Assert.IsNull(cashRegister.Bracket);
            Assert.IsNull(cashRegister.WebOrder);
        }

        [TestMethod]
        public void REQ_7_PayBillWithCheckAndBC()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            var firstSelectedArticle = _articlesService.GetArticles("0102030405").First();
            cashRegister.AddArticle(firstSelectedArticle);

            var secondSelectedArticle = _articlesService.GetArticles("0203040506").First();
            cashRegister.AddArticle(secondSelectedArticle);

            var bracketTotalPrice = firstSelectedArticle.Price + secondSelectedArticle.Price;
            Assert.AreEqual(bracketTotalPrice, cashRegister.GetRemainsDependent());

            double bcAmount = 2;
            double checkAmount = 7.5;

            cashRegister.PayWithBC(bcAmount);
            Assert.IsFalse(cashRegister.CanCompleteTransaction);
            Assert.AreEqual(bracketTotalPrice - bcAmount, cashRegister.GetRemainsDependent());

            cashRegister.PayWithCheck(checkAmount);
            Assert.IsTrue(cashRegister.CanCompleteTransaction);
            Assert.AreEqual(0, cashRegister.GetRemainsDependent());

            Assert.AreEqual(2, cashRegister.Bracket.Transactions.Count());

            var firstTransaction = cashRegister.Bracket.Transactions.ElementAt(0);
            Assert.AreEqual(bcAmount, firstTransaction.Amount);
            Assert.AreEqual(TransactionType.BC, firstTransaction.Type);

            var secondTransaction = cashRegister.Bracket.Transactions.ElementAt(1);
            Assert.AreEqual(checkAmount, secondTransaction.Amount);
            Assert.AreEqual(TransactionType.Check, secondTransaction.Type);

            cashRegister.CompleteTransaction();
            Assert.IsNull(cashRegister.Bracket);
            Assert.IsNull(cashRegister.WebOrder);
        }

        [TestMethod]
        public void REQ_7_PayBillWithReceiptAndBill()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            var cashRegister = new CashRegister(cashier);

            var firstSelectedArticle = _articlesService.GetArticles("0102030405").First();
            cashRegister.AddArticle(firstSelectedArticle);

            var secondSelectedArticle = _articlesService.GetArticles("0203040506").First();
            cashRegister.AddArticle(secondSelectedArticle);

            var bracketTotalPrice = firstSelectedArticle.Price + secondSelectedArticle.Price;
            cashRegister.PayWithCash(bracketTotalPrice);

            Assert.IsTrue(cashRegister.CanCompleteTransaction);

            var receipt = cashRegister.GetReceipt();
            Assert.IsTrue(receipt.Contains("Receipt"));
            Assert.IsTrue(receipt.Contains($"{firstSelectedArticle.Name} - 1 - {firstSelectedArticle.Price}€"));
            Assert.IsTrue(receipt.Contains($"{secondSelectedArticle.Name} - 1 - {secondSelectedArticle.Price}€"));
            Assert.IsTrue(receipt.Contains($"Cash : {bracketTotalPrice}€"));
            Assert.IsTrue(receipt.Contains("Change : 0€"));
            cashRegister.PrintReceipt(receipt);

            var bill = cashRegister.GetBill();
            Assert.IsTrue(bill.Contains("Bill"));
            Assert.IsTrue(bill.Contains($"{firstSelectedArticle.Name} - 1 - {firstSelectedArticle.Price}€"));
            Assert.IsTrue(bill.Contains($"{secondSelectedArticle.Name} - 1 - {secondSelectedArticle.Price}€"));
            Assert.IsTrue(bill.Contains($"Cash : {bracketTotalPrice}€"));
            Assert.IsTrue(bill.Contains("Change : 0€"));
            cashRegister.PrintBill(bill);

            cashRegister.CompleteTransaction();
            Assert.IsNull(cashRegister.Bracket);
            Assert.IsNull(cashRegister.WebOrder);
        }
    }
}
