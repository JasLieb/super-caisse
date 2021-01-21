using System;
using System.Collections.Generic;
using System.Text;
using SuperCaisse.Model;

namespace SuperCaisse.Services
{
    public class WebSession : SalesDevice
    {
        private ShopInfosService _shopInfosService = new ShopInfosService();
        private WebOrderService _webOrderService = new WebOrderService();

        public Customer Customer;

        public string SelectedIdShopClickNCollectId { get; private set; }
        public DeliveryMode SelectedDeliveryMode { get; private set; }

        public bool CanFinalizeOrder => Customer != null;
        public override bool CanCompleteTransaction => 
            base.CanCompleteTransaction 
            || SelectedDeliveryMode == DeliveryMode.ClickCollectPaymentInShop;

        public Customer MakeCustomer(
            string name, 
            string phoneNumber, 
            string mail, 
            string password, 
            string physicalAddress, 
            string zipCode, 
            string city
        )
        {
            return PersonFactory.MakeCustomer(
                name,
                PersonFactory.MakeDetails(
                    phoneNumber,
                    mail,
                    physicalAddress,
                    zipCode,
                    city
                ),
                password
            );
        }

        public void ConnectCustomer(Customer customer)
        {
            Customer = customer;
        }

        public void DisconnectCustomer()
        {
            Customer = null;
            Bracket = null;

        }

        public void SetAtHomeDeliveryMode()
        {
            SelectedDeliveryMode = DeliveryMode.AtHome;
        }

        public void SetClickNCollectDeliveryMode(string id)
        {
            SelectedDeliveryMode = DeliveryMode.ClickCollect;
            SelectedIdShopClickNCollectId = id;
        }

        public void SetClickCollectPaymentInShopDeliveryMode(string id)
        {
            SelectedDeliveryMode = DeliveryMode.ClickCollectPaymentInShop;
            SelectedIdShopClickNCollectId = id;
        }

        public bool PayWtihBC(string BCId, string BCDateExpiration, string BCCryptogram)
        {
            // TODO BC payement check with banks
            Bracket.AddTransaction(TransactionType.BC, GetRemainsDependent());
            return true;
        }

        public void CompleteTransaction()
        {
            var webOrder = new WebOrder(
                Customer,
                SelectedDeliveryMode,
                Bracket
            );

            if (SelectedDeliveryMode == DeliveryMode.AtHome)
            {
                _webOrderService.EmitOrder(
                    webOrder
                );
            }
            else
            {
                var shop = _shopInfosService.GetShop(SelectedIdShopClickNCollectId);
                _webOrderService.EmitClickAndCollect(
                    shop,
                    webOrder
                );
            }

            Customer.SendMailWebOrderCompleted(webOrder);
        }

        public Shop GetSelectedShop()
        {
            return _shopInfosService.GetShop(SelectedIdShopClickNCollectId);
        }
    }
}
