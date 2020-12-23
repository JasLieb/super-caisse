using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Services.Tests
{
    [TestClass]
    public class ProviderServiceTest
    {
        private AuthentificationService _authentificationService = new AuthentificationService();
        private ProviderService _providerService = new ProviderService();

        [TestMethod]
        public void REQ_11_AddNewProvider()
        {
            _authentificationService.ConnectStorekeeper("MatMatStock", "brico2000clavy");
            var newProvider = _providerService.AddProvider(
                "Courage",
                new Details(
                    "0606060606",
                    "Courage@Courage.com",
                    "Middle of",
                    "666",
                    "Nowhere"
                ),
                new Catalog()
            );

            var providerFound = _providerService.GetProvider(newProvider.Name);
            Assert.IsNotNull(providerFound);
        }
    }
}
