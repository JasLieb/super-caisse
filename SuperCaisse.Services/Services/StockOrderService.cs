using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services
{
    public class StockOrderService
    {
        private List<StockOrder> _stockOrders { get; }

        public StockOrderService()
        {
            _stockOrders = new List<StockOrder>()
            {
                new StockOrder(
                    Guid.NewGuid().ToString(),
                    new Provider("P1", null, null),
                    new Storekeeper("toto", "toto", "toto", "toto", "toto", DateTime.Now, null),
                    new List<Article>(),
                    new OrderReport(
                        OrderReportStatus.InTransit,
                        DateTime.Now
                    )
                ),
                new StockOrder(
                    Guid.NewGuid().ToString(),
                    new Provider("P1", null, null),
                    new Storekeeper("toto", "toto", "toto", "toto", "toto", DateTime.Now, null),
                    new List<Article>(),
                    new OrderReport(
                        OrderReportStatus.Delivered,
                        DateTime.Now,
                        DateTime.Now
                    )
                )
            };
        }

        public StockOrder AddStockOrder(
            Provider provider,
            Storekeeper backer,
            IEnumerable<Article> articles
        )
        {
            var stockOrder = new StockOrder(
                Guid.NewGuid().ToString(),
                provider,
                backer,
                articles,
                new OrderReport(
                    OrderReportStatus.Created,
                    DateTime.Now
                )
            );

            _stockOrders.Add(stockOrder);

            return stockOrder;
        }

        public void SendStockOrder(string id)
        {
            var stockOrderToSend = GetStockOrder(id);
            stockOrderToSend.Provider.SendMail(stockOrderToSend);
            _stockOrders.Remove(stockOrderToSend);
            stockOrderToSend.UpdateReport(status: OrderReportStatus.Asked);
            _stockOrders.Add(stockOrderToSend);
        }

        public StockOrder GetStockOrder(string id)
        {
            return _stockOrders.Find(
                stockOrder => stockOrder.Id == id
            );
        }

        public IEnumerable<StockOrder> GetAllStockOrders()
        {
            return _stockOrders;
        }

        public IEnumerable<StockOrder> GetInTransitStockOrders()
        {
            return _stockOrders.Where(
                stockOrder => 
                    stockOrder.Report.Status == OrderReportStatus.InTransit
            );
        }

        public void RecieveOrder(
            string id, 
            int note, 
            string comment, 
            string photoFilePath
        )
        {
            var deliveredStockOrder = GetStockOrder(id);
            deliveredStockOrder.UpdateReport(
                OrderReportStatus.Delivered,
                DateTime.Now,
                note,
                comment,
                photoFilePath
            );
        }
    }
}
