using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class CustomerConnectionTest
    {
        private WebAuthentificationService _webAuthentificationService = new WebAuthentificationService();

        [TestMethod]
        public void REQ_16_RegisterNewCustomer()
        {
            var customer = _webAuthentificationService.AddCustomer(
                "Johnny B. Good",
                "0666066600",
                "johnny.b.good@berry.com",
                "funnypassword",
                "my address",
                "31666",
                "Ville"
            );
            Assert.IsNotNull(customer);
            customer.SendMailRegistrationSuccessed();
            var connectedCustomer = _webAuthentificationService.ConnectCustomer(
                customer.Details.MailAddress,
                customer.Password
            );
            Assert.IsNotNull(connectedCustomer);
        }

        [TestMethod]
        public void REQ_16_ConnectCustomer()
        {
            var customer = _webAuthentificationService.ConnectCustomer(
                "already@registered.com",
                "notfunnypassword"
            );
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void REQ_16_ConnectCustomer_WrongIdentifiants()
        {
            _webAuthentificationService.ConnectCustomer(
                "already@registered.com",
                "notfunnypasswordw"
            );
        }

        [TestMethod]
        public void REQ_16_DisconnectConnectCustomer()
        {
            var customer = _webAuthentificationService.ConnectCustomer(
                "already@registered.com",
                "notfunnypassword"
            );
            Assert.IsNotNull(customer);
            var isDisconnect = _webAuthentificationService.DisconnectCustomer("already@registered.com");
            Assert.IsTrue(isDisconnect);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void REQ_16_DisconnectConnectCustomer_NotConnectedCustomer()
        {
            _webAuthentificationService.DisconnectCustomer("a");
        }
    }
}
