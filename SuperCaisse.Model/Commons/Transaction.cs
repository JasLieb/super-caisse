using System.Collections.Generic;
using System.ComponentModel;

namespace SuperCaisse.Model
{
    public class TransactionType
    {
        private TransactionType(string value) { Value = value; }
        private string Value { get; }
        
        public static TransactionType Cash { get { return new TransactionType("Cash"); } }
        public static TransactionType BC { get { return new TransactionType("BC"); } }
        public static TransactionType Check { get { return new TransactionType("Check"); } }
        public static TransactionType CashChange { get { return new TransactionType("Change"); } }

        public override bool Equals(object obj)
        {
            return obj is TransactionType type 
                && Value == type.Value;
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class Transaction
    {
        public TransactionType Type { get; }
        public double Amount { get; }
        
        public Transaction(TransactionType type, double amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}