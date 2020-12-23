using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Model
{
    public class StockOrder
    {
        public string Id { get; }
        public Provider Provider { get; }
        public Storekeeper Backer { get; }
        public IEnumerable<Article> Articles { get; }
        public OrderReport Report { get; private set; }

        public StockOrder(
            string id,
            Provider provider,
            Storekeeper backer,
            IEnumerable<Article> articles,
            OrderReport report
        )
        {
            Id = id;
            Provider = provider;
            Backer = backer;
            Articles = articles;
            Report = report;
        }

        public double GetPrice() => Articles.Sum(article => article.Price);

        public void UpdateReport(
            OrderReportStatus? status = null, 
            DateTime? deliveredDate = null
        )
        {
            Report = new OrderReport(
                status ?? Report.Status,
                Report.OrderDate,
                deliveredDate ?? Report.DeliveryDate
            );
        }
    }
}
