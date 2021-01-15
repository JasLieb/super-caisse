using System;
using System.Collections.Generic;
using System.Text;
using SuperCaisse.Model;

namespace SuperCaisse.Services
{
    public class WebSite
    {
        private WebAuthentificationService _webAuthentification = new WebAuthentificationService();

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
            return _webAuthentification.AddCustomer(
                name,
                phoneNumber,
                mail,
                physicalAddress,
                zipCode,
                city,
                password
            );
        }

        public Customer ConnectCustomer(string mailAddress, string password)
        {
            return _webAuthentification.ConnectCustomer(mailAddress, password);
        }

        public bool DisconnectCustomer(string mailAddress)
        {
            return _webAuthentification.DisconnectCustomer(mailAddress);
        }
    }
}
