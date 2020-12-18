using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperCaisse.Model
{
    public enum PaymentType
    {
        Cheque,
        CB,
        Espece
    }

    public class Payment
    {
        PaymentType type;
        int total;
    }

    public class Facture
    {
        public Facture(
            Article[] articles,
            User user,
            string billAdress,
            Payment[] payments
        )
        {
            Articles = articles; // List of articles
            User = user;         // User who buy articles
            Payments = payments; // Paiement type. Can have multiple payment with different method (CB, cheque, espece)
            TotalAmount = getTotalAmount(articles); // Total payment
            BillAdress = billAdress; // Bill adress can be different from user's home
            BillID = generateBillID(); // Generate a random atomic ID 
            CreatedDate = DateTime.Now; // Date when created that bill
        }

        private double getTotalAmount(Article[] articles)
        {
            return articles.Sum(article => article.Price)
        }

        private string generateBillID()
        {
            // Generate random bill ID
            return "";
        }

        public Article[] Articles { get; private set; }
        public User User { get; private set; }
        public Payment[] Payments { get; private set; }
        public double TotalAmount { get; private set; }
        public string BillAdress { get; private set; }
        public string BillID { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }
}
