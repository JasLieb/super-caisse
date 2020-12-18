using SuperCaisse.Model;
using System;
using System.Linq;

namespace SuperCaisse.Services
{
    public class AuthentificationService
    {
        private Employee[] _users ;

        public AuthentificationService()
        {
            _users = new Employee[]
            {
                new Storekeeper(
                    "Mathieu",
                    "Dicaprio",
                    "3",
                    "MatMatStock",
                    "brico2000clavy", 
                    DateTime.Now, 
                    new Details(
                        "0666666666",
                        "mathieu.dicaprio@brico2000.fr",
                        "21 Baker street",
                        "EC2P 2E",
                        "London"
                    )
                ),
                new Cashier(
                    "Lopez", 
                    "Cindy", 
                    "2", 
                    "123456",
                    DateTime.Now,
                    new Details(
                        "077777777",
                        "cindy.lopez@brico2000.fr",
                        "75 rue de Paris",
                        "75000",
                        "Paris"
                    )
                )
            };
        }

        public Cashier ConnectCashier(string codePin)
        {
            var userFound = _users
                .Where(
                    user =>
                        user is Cashier cashier
                        && cashier.Login == codePin
                );
            if(userFound.Count() != 1)
            {
                throw new Exception("Cashier not found");
            }
            
            return (Cashier) userFound.First();
        }

        public Storekeeper ConnectStorekeeper(string login, string password)
        {
            var userFound = _users
                .Where(
                    user =>
                        user is Storekeeper storekeeper
                        && storekeeper.Login == login
                        && storekeeper.Password == password
                );
            if (userFound.Count() != 1)
            {
                throw new Exception("Storekeeper not found");
            }

            return (Storekeeper) userFound.First();
        }
    }
}