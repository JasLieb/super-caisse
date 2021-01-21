using SuperCaisse.Model;
using System;
using System.Collections.Generic;

namespace SuperCaisse.Services
{
    public class WebOrderService
    {
        private List<WebOrder> _webOrdersToDeliver = new List<WebOrder>();
        private WebToShopProxyService _webToShopProxyService = new WebToShopProxyService();

        public void EmitOrder(WebOrder webOrder)
        {
            _webOrdersToDeliver.Add(webOrder);
        }

        public void EmitClickAndCollect(Shop shop, WebOrder webOrder)
        {
            _webToShopProxyService.EmitClickAndCollect(
                shop,
                webOrder
            );
        }
    }
}