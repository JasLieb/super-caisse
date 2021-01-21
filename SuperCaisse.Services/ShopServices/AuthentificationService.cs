using SuperCaisse.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperCaisse.Services
{
    public class AuthentificationService
    {
        private IEnumerable<Employee> _employees;
        private IList<Employee> _connectedEmployees = new List<Employee>();

        public AuthentificationService()
        {
            _employees = new List<Employee>()
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
            var userFound = _employees
                .Where(
                    user =>
                        user is Cashier cashier
                        && cashier.Login == codePin
                );

            var employee = userFound.First();
            _connectedEmployees.Add(employee);

            return (Cashier) employee;
        }

        public Storekeeper ConnectStorekeeper(string login, string password)
        {
            var userFound = _employees
                .Where(
                    user =>
                        user is Storekeeper storekeeper
                        && storekeeper.Login == login
                        && storekeeper.Password == password
                );

            var employee = userFound.First();
            _connectedEmployees.Add(employee);

            return (Storekeeper) userFound.First();
        }

        public bool DisconnectEmployee(string login)
        {
            var employeeFound =
                _employees.Where(
                    employee =>
                        employee.Login == login
                )
                .First();

            return _connectedEmployees.Remove(employeeFound);
        }
    }
}