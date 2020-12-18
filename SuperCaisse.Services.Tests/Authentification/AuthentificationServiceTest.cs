using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class AuthentificationServiceTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();

        [TestMethod]
        public void ConnectCashier_RigthMatriculePassword()
        {
            Assert.IsTrue(
                _authentificationService.ConnectCashier("123456")
            );
        }

        [TestMethod]
        public void ConnectCashier_WrongMatriculePassword()
        {
            Assert.IsFalse(
                _authentificationService.ConnectCashier("654321")
            );
        }

        [TestMethod]
        public void ConnectStorekeeper_RigthMatriculePassword()
        {
            Assert.IsTrue(
                _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy")
            );
        }

        [TestMethod]
        public void ConnectStorekeeper_WrongMatriculePassword()
        {
            Assert.IsFalse(
                _authentificationService.ConnectStorekeeper("-1", "654321")
            );
        }
    }
}
