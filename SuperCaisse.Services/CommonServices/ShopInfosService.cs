using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services
{
    public class ShopInfosService
    {
        private ClickNCollectService _clickNCollectServiceToulouse = new ClickNCollectService();
        private ClickNCollectService _clickNCollectServiceBalma = new ClickNCollectService();
        
        private IEnumerable<Shop> _shops ;

        public ShopInfosService()
        {
            _shops = new List<Shop>()
            {
                new Shop(
                    "0",
                    new Address(
                        "2 rue de la croix de Pierre",
                        "31300",
                        "Toulouse"
                    ),
                    _clickNCollectServiceToulouse,
                    new ShopToWebProxyService(_clickNCollectServiceToulouse)
                ),
                new Shop(
                    "1",
                    new Address(
                        "10 boulevard de la paix",
                        "31130",
                        "Balma"
                    ),
                    _clickNCollectServiceBalma,
                    new ShopToWebProxyService(_clickNCollectServiceBalma)
                )
            };
        }

        public IEnumerable<Shop> GetShops()
        {
            return _shops;
        }

        public Shop GetShop(string selectedIdShopClickNCollectId)
        {
            return _shops.First(shop => shop.Id == selectedIdShopClickNCollectId);
        }
    }
}
