using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services
{
    public class StockOrderService
    {
        private List<StockOrder> _stockOrders = new List<StockOrder>();

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
                new OrderReport()
            );

            _stockOrders.Add(stockOrder);

            return stockOrder;
        }

        public void SendStockOrder(string id)
        {
            var stockOrderToSend = GetStockOrder(id);
            stockOrderToSend.Provider.SendMail(stockOrderToSend);
            _stockOrders.Remove(stockOrderToSend);
            stockOrderToSend.UpdateStatus(OrderReportStatus.Asked);
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
    }
}
