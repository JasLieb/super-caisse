using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Services
{
    public class WebToShopProxyService
    {
        public void EmitClickAndCollect(
            Shop shop, 
            WebOrder webOrder
        )
        {
            shop.SendNewClickNCollect(
                webOrder
            );
        }
    }
}
