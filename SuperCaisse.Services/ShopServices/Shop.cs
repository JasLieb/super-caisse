
using SuperCaisse.Model;

namespace SuperCaisse.Services
{
    public class Shop
    {
        public string Id { get; }
        public Address Address { get; }
        public ClickNCollectService ClickNCollectService { get; }
        public ShopToWebProxyService Proxy { get; }

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
    }
}
