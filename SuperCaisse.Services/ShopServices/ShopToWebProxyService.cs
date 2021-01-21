using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Services
{
    public class ShopToWebProxyService
    {
        private ClickNCollectService _observer { get; }

        public ShopToWebProxyService(ClickNCollectService service)
        {
            _observer = service;
        }

        public void SendNewClickNCollect(WebOrder webOrder)
        {
            _observer.AddWebOrder(webOrder);
        }

        public IEnumerable<WebOrder> GetClickAndCollectOrder()
        {
            return _observer.GetWebOrders();
        }
    }
}
