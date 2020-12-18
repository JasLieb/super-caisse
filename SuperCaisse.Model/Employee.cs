using System;

namespace SuperCaisse.Model
{
    public abstract class Employee : Person
    {
        public Employee(
            string firstName, 
            string lastName, 
            string matricule, 
            string login, 
            DateTime startDate,
            Details details
        ) : base(
            $"{firstName} {lastName}",
            details
        )
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Matricule = matricule ?? throw new ArgumentNullException(nameof(matricule));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            StartDate = startDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Matricule { get; set; }
        public string Login { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class Cashier : Employee
    {
        public Cashier(
            string firstName, 
            string lastName, 
            string matricule, 
            string login, 
            DateTime startDate,
            Details details
        ) : base(
            firstName, 
            lastName, 
            matricule, 
            login, 
            startDate,
            details
        )
        {
        }
    }

    public class Storekeeper : Employee 
    {
        public string Password { get; }

        public Storekeeper(
            string firstName, 
            string lastName, 
            string matricule, 
            string login, 
            string password, 
            DateTime startDate,
            Details details
        ) : base(
            firstName, 
            lastName, 
            matricule, 
            login, 
            startDate,
            details
        )
        {
            Password = password;
        }
    }
}