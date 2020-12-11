using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCaisse.Services
{
    public class AuthentificationService
    {
        private User[] _users ;

        public AuthentificationService()
        {
            _users = new User[]
            {
                new User("Mathieu","Pages","3","MatMatStock","brico2000clavy", UserRoles.Storekeeper),
                new User("Lopez", "Cindy", "2", "123456", string.Empty, UserRoles.Cashier)
            };
        }

        public bool ConnectCashier(string codePin)
        {
            return _users
                .Where(
                    user => 
                        user.Role == UserRoles.Cashier
                        && user.Login == codePin
                )
                .Count() == 1;
        }

        public bool ConnectStorekeeper(string login, string password)
        {
            return _users
                .Where(
                    user =>
                        user.Role == UserRoles.Storekeeper
                        && user.Login == login
                        && user.Password == password
                )
                .Count() == 1;
        }
    }
}