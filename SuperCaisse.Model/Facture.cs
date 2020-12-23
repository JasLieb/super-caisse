//using System;
//using System.Collections.Generic;

//namespace SuperCaisse.Model
//{
//    public enum PaymentType
//    {
//        Cheque,
//        CB,
//        Espece
//    }

//    public class Payment
//    {
//        PaymentType type;
//        int total;
//    }

//    public class Facture
//    {
//        public Facture(
//            Article[] articles,
//            User user,
//            string billAdress,
//            Payment[] payments,
//            string comment
//        )
//        {
//            Articles = articles; // List of articles
//            User = user;         // User who buy articles
//            Payments = payments; // Paiement type. Can have multiple payment with different method (CB, cheque, espece)
//            TotalAmount = getTotalAmount(articles); // Total payment
//            Comment = comment;   // Comment for that Bill
//            BillAdress = billAdress; // Bill adress can be different from user's home
//            BillID = generateBillID(); // Generate a random atomic ID 
//            CreatedDate = DateTime.Now; // Date when created that bill
//        }

//        private double getTotalAmount(Article[] articles)
//        {
//            double montant = 0;

//            foreach (var article in articles)
//            {
//                // montant += article.Price * number
//            }

//            return montant;
//        }

//        private string generateBillID()
//        {
//            // Generate random bill ID
//            return "";
//        }

//        public Article[] Articles { get; private set; }
//        public User User { get; private set; }
//        public Payment[] Payments { get; private set; }
//        public double TotalAmount { get; private set; }
//        public string Comment { get; set; }
//        public string BillAdress { get; private set; }
//        public string BillID { get; private set; }
//        public DateTime CreatedDate { get; private set; }
//    }
//}
