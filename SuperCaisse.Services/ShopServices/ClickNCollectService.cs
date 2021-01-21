using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperCaisse.Services
{
    public class ClickNCollectService
    {
        private List<WebOrder> _webOrders = new List<WebOrder>();
        
        public void AddWebOrder(WebOrder webOrder)
        {
            _webOrders.Add(webOrder);
        }

        public IEnumerable<WebOrder> GetWebOrders()
        {
            return _webOrders;
        }

        public IEnumerable<WebOrder> FindWebOrders(string customerName)
        {
            return _webOrders.Where(
                webOrder => webOrder.Customer.Name.Contains(customerName)
            );
        }
    }
}