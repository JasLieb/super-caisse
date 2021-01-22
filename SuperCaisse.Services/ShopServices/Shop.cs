
using SuperCaisse.Model;
using System;
using System.Collections.Generic;

namespace SuperCaisse.Services
{
    public class Shop
    {
        public string Id { get; }
        public Address Address { get; }
        public ClickNCollectService ClickNCollectService { get; }
        private ShopToWebProxyService Proxy { get; }

        public Shop(
            string id, 
            Address address,
            ClickNCollectService clickNCollectService,
            ShopToWebProxyService shopToWebProxyService
        )
        {
            Id = id;
            Address = address;
            ClickNCollectService = clickNCollectService;
            Proxy = shopToWebProxyService;
        }

        public void SendNewClickNCollect(WebOrder webOrder)
        {
            Proxy.SendNewClickNCollect(webOrder);
        }

        public IEnumerable<WebOrder> GetClickAndCollectOrder()
        {
            return Proxy.GetClickAndCollectOrder();
        }
    }
}
