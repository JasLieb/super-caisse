using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services
{
    public class ProviderService
    {
        private List<Provider> _providers { get; }

        public ProviderService()
        {
            _providers = new List<Provider>()
            {
                new Provider(
                    "BricoWorld",
                    new Details(
                        "0235353535",
                        "supply@bricoworld.com",
                        "253 ZI des quatres vents",
                        "31250",
                        "Revel"
                    ),
                    new Catalog()
                ),
                new Provider(
                    "H.P.L.", 
                    new Details(
                        "0666666666", 
                        "contact@HPL.com",
                        "Twenty Thousand Leagues Under the Sea",
                        "023456",
                        "Sea"
                    ),
                    new Catalog()
                )
            };
        }

        public Provider GetProvider(string name)
        {
            return 
                _providers.Where(
                    provider => provider.Name == name
                )
                .First();
        }

        public Provider AddProvider(
            string name, 
            Details details, 
            Catalog catalog
        )
        {
            var newProvider = new Provider(
                name,
                details,
                catalog
            );

            _providers.Add(newProvider);

            return newProvider;
        }
    }
}
