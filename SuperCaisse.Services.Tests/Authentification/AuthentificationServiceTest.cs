using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class AuthentificationServiceTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();

        [TestMethod]
        public void ConnectCashier_RigthMatriculePassword()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            Assert.IsNotNull(cashier);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Cashier not found")]
        public void ConnectCashier_WrongMatriculePassword()
        {
            var cashier = _authentificationService.ConnectCashier("654321");
        }

        [TestMethod]
        public void ConnectStorekeeper_RigthMatriculePassword()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            Assert.IsNotNull(storekeeper);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Storekeeper not found")]
        public void ConnectStorekeeper_WrongMatriculePassword()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("-1", "654321");
        }
    }
}
