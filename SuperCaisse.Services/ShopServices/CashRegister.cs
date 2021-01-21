using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Services
{
    public class CashRegister : SalesDevice
    {
        public Cashier Cashier { get; }
        public WebOrder WebOrder { get; private set; }

        public CashRegister(Cashier cashier)
        {
            Cashier = cashier;
        }

        public void PayWithCash(double amount)
        {
            var remainAmount = GetRemainsDependent();
            Bracket.AddTransaction(TransactionType.Cash, amount);
            
            if (amount == remainAmount)
            {
                Bracket.AddTransaction(TransactionType.CashChange, 0);
            }
        }

        public void GiveBackChange(double amount)
        {
            Bracket.AddTransaction(TransactionType.CashChange, amount);
        }

        public void PayWithBC(double amount)
        {
            Bracket.AddTransaction(TransactionType.BC, amount);
        }

        public void ReceiptWebOrder(WebOrder webOrder)
        {
            RestoreBracket(webOrder.Bracket);
        }

        public void CompleteTransaction()
        {
            if(GetRemainsDependent() != 0)
            {
                throw new InvalidOperationException();
            }

            Bracket = null;
            WebOrder = null;
        }

        public void PayWithCheck(double amount)
        {
            Bracket.AddTransaction(TransactionType.Check, amount);
        }

        public void PrintReceipt(string receipt)
        {
            // Send to the receipt printer
        }

        public void PrintBill(string bill)
        {
            // Send to the bill printer
        }

        // These methods could be as private but in the need or the exercise
        // We have ignored an isolated test for theses builders
        public string GetReceipt()
        {
            var receiptBuilder = new ReceiptBuilder();
            return receiptBuilder.Build(Bracket);
        }

        public string GetBill()
        {
            var billBuilder = new BillBuilder();
            return billBuilder.Build(Bracket);
        }
    }
}
