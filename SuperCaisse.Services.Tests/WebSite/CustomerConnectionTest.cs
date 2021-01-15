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
        [TestMethod]
        public void REQ_16_RegisterNewCustomer()
        {
            var webSite = new WebSite();
            var customer = webSite.MakeCustomer(
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
            var connectedCustomer = webSite.ConnectCustomer(
                customer.Details.MailAddress,
                customer.Password
            );
            Assert.IsNotNull(connectedCustomer);
        }

        [TestMethod]
        public void REQ_16_ConnectCustomer()
        {
            var webSite = new WebSite();
            var customer = webSite.ConnectCustomer(
                "already@registered.com",
                "notfunnypassword"
            );
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void REQ_16_ConnectCustomer_WrongIdentifiants()
        {
            var webSite = new WebSite();
            var customer = webSite.ConnectCustomer(
                "already@registered.com",
                "notfunnypasswordw"
            );
        }

        [TestMethod]
        public void REQ_16_DisconnectConnectCustomer()
        {
            var webSite = new WebSite();
            var customer = webSite.ConnectCustomer(
                "already@registered.com",
                "notfunnypassword"
            );
            Assert.IsNotNull(customer);
            var isDisconnect = webSite.DisconnectCustomer("already@registered.com");
            Assert.IsTrue(isDisconnect);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void REQ_16_DisconnectConnectCustomer_NotConnectedCustomer()
        {
            var webSite = new WebSite();
            var isDisconnected = webSite.DisconnectCustomer("a");
        }
    }
}
