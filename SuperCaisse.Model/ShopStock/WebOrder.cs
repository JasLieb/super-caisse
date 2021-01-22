using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Model
{
    public enum DeliveryMode
    {
        AtHome,
        ClickCollect,
        ClickCollectPaymentInShop
    }

    public class WebOrder
    {
        public WebOrder(
            Customer customer, 
            DeliveryMode deliveryMode, 
            Bracket bracket
        )
        {
            Customer = customer;
            DeliveryMode = deliveryMode;
            Bracket = bracket;
        }

        public Customer Customer { get; }
        public DeliveryMode DeliveryMode { get; }
        public Bracket Bracket { get; }
    }
}
