using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCaisse.Model
{
    public enum UserRoles
    {
        Administrator,
        Cashier,
        Storekeeper
    }

    public class User
    {
        public User(
            string firstName, 
            string lastName, 
            string matricule, 
            string login, 
            string password, 
            UserRoles role
        )
        {
            FirstName = firstName;
            LastName = lastName;
            Matricule = matricule;
            Login = login;
            Password = password;
            Role = role;
            CreatedDate = DateTime.Now;
        }

        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Matricule { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
