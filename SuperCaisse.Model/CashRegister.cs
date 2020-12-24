using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Model
{
    public class CashRegister
    {
        public Cashier Cashier { get; }
        public Bracket Bracket { get; private set; }
        public bool IsCompletedTransaction => GetRemainsDependent() == 0;

        public CashRegister(Cashier cashier)
        {
            Cashier = cashier;
        }

        public void AddArticle(Article selectedArticle)
        {
            if (Bracket == null)
                Bracket = new Bracket();

            Bracket.AddArticle(selectedArticle);
        }

        public Bracket MakeBracketMemento()
        {
            var bracketMemento = Bracket;
            Bracket = null;
            return bracketMemento;
        }

        public void RestoreBracket(Bracket savedBracket)
        {
            if (Bracket != null)
                throw new InvalidOperationException();

            Bracket = savedBracket;
        }

        public double GetRemainsDependent()
        {
            return Bracket.GetTotalPrice() - Bracket.GetTotalPaid();
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

        public void PayWithCheck(double amount)
        {
            Bracket.AddTransaction(TransactionType.Check, amount);
        }

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

        public void PrintReceipt(string receipt)
        {
            // Send to the receipt printer
        }

        public void PrintBill(string bill)
        {
            // Send to the bill printer
        }
    }
}
