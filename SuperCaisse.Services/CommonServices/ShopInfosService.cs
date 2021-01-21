using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services
{
    public class ShopInfosService
    {
        // This service or the way it was implemented now is a "joker"
        // It is meaning in the future, this service will not contains any Shop reference
        // Ask through a DB loading mechanism, a ShopInfo object with only an Id, an Address and a Proxy handler
        // In the context of the exercise, this choce of implementation was taken

        // Only for ShopInfosService creation
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
