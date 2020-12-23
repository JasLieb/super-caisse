using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class AuthentificationDisconnectionTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();

        [TestMethod]
        public void REQ_3_DisconnectCashier_RigthMatricule_LoggedEmployee()
        {
            var cashier = _authentificationService.ConnectCashier("123456");
            Assert.IsNotNull(cashier);

            _authentificationService.DisconnectEmployee(cashier.Login);
        }

        [TestMethod]
        public void REQ_3_DisconnectCashier_NotLoggedEmployee()
        {
            Assert.IsFalse(
                _authentificationService.DisconnectEmployee("123456")
            );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void REQ_3_DisconnectCashier_UnknowEmployee()
        {
            _authentificationService.DisconnectEmployee("0");
        }

        [TestMethod]
        public void REQ_9_DisconnectStorekeeper_LoggedEmployee()
        {
            var storekeeper = _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            Assert.IsNotNull(storekeeper);

            _authentificationService.DisconnectEmployee(storekeeper.Login);
        }

        [TestMethod]
        public void REQ_9_DisconnectStorekeeper_NotLoggedEmployee()
        {
            Assert.IsFalse(
                _authentificationService.DisconnectEmployee("MatMatStock")
            );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void REQ_9_DisconnectStorekeeper_UnknowEmployee()
        {
            _authentificationService.DisconnectEmployee("654321");
        }
    }
}
