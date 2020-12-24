using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Model
{
    public class Bracket : ArticleContainer
    {
        public IList<Transaction> Transactions { get; }

        public Bracket()
        {
            Transactions = new List<Transaction>();
        }

        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }
        
        public double GetTotalPrice()
        {
            return Articles.Sum(
                article => article.Price
            );
        }

        public void AddTransaction(TransactionType type, double amount)
        {
            Transactions.Add(
                new Transaction(type, amount)
            );
        }

        public double GetTotalPaid()
        {
            return Transactions.Sum(
                transaction => 
                    !transaction.Type.Equals(TransactionType.CashChange)
                        ? transaction.Amount
                        : -transaction.Amount
            );
        }
    }
}
