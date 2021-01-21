using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperCaisse.Services
{
    public class WebAuthentificationService : AuthentificationService
    {
        private IList<Customer> _customers;
        private IList<Customer> _connectedCustomers = new List<Customer>();

        public WebAuthentificationService()
        {
            _employees = new List<Employee>()
            {
                _personFactory.MakeStorekeeper(
                    "Quentin",
                    "Tarantino",
                    "4",
                    "MatParisStock",
                    "entrepotfantome",
                    DateTime.Now,
                    _personFactory.MakeDetails(
                        "0777777777",
                        "quentin.tarantino@brico2000.fr",
                        "21 Hollywood Boulveard",
                        "90028",
                        "Los Angeles"
                    )
                )
            };
            _customers = new List<Customer>()
            {
                _personFactory.MakeCustomer(
                    "Already",
                    new Details(
                        "0604050405",
                        "already@registered.com",
                        "my address bis",
                        "31666",
                        "Ville"
                    ),
                    "notfunnypassword"
                )
            };
        }

        public Customer ConnectCustomer(string mailAddress, string password)
        {
            var userFound = _customers
                .Where(
                    user =>
                        user is Customer customer
                        && customer.Details.MailAddress == mailAddress
                        && customer.Password == password
                );

            var customerFound = userFound.First();
            _connectedCustomers.Add(customerFound);

            return customerFound;
        }

        public bool DisconnectCustomer(string mailAddress)
        {
            var customerFound =
                _connectedCustomers
                .Where(
                    customer =>
                        customer.Details.MailAddress == mailAddress
                )
                .First();

            return _connectedCustomers.Remove(customerFound);
        }

        public Customer AddCustomer(
            string name,
            string phoneNumber,
            string mail,
            string physicalAddress,
            string zipCode,
            string city,
            string password
        )
        {
            var customer = _personFactory.MakeCustomer(
                name,
                _personFactory.MakeDetails(
                    phoneNumber,
                    mail,
                    physicalAddress,
                    zipCode,
                    city
                ),
                password
            );

            _customers.Add(customer);
            return customer;
        }
    }
}