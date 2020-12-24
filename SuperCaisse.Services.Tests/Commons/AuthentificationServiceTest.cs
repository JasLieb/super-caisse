using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Services;
using System;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class AuthentificationServiceTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();

        [TestMethod]
        public void REQ_2_ConnectCashier_RigthMatriculePassword()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            Assert.IsNotNull(cashier);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void REQ_2_ConnectCashier_WrongMatriculePassword()
        {
            _authentificationService.ConnectCashier("654321");
        }

        [TestMethod]
        public void REQ_8_ConnectStorekeeper_RigthMatriculePassword()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            Assert.IsNotNull(storekeeper);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void REQ_8_ConnectStorekeeper_WrongMatriculePassword()
        {
            _authentificationService.ConnectStorekeeper("-1", "654321");
        }
    }
}
