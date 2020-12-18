using System;

namespace SuperCaisse.Model
{
    public class Provider : Person
    {
        public Catalog Catalog { get; }

        public Provider(string name, Details details, Catalog catalog)
            : base(name, details)
        {
            Catalog = catalog;
        }

        public void SendMail(StockOrder stockOrder)
        {
            throw new NotImplementedException();
        }
    }
}