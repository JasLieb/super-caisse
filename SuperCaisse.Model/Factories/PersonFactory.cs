using System;

namespace SuperCaisse.Model
{
    public class PersonFactory
    {
        public PersonFactory()
        {

        }

        public Customer MakeCustomer(string name, Details details, string password)
        {
            return new Customer(
                name,
                details,
                password
            );
        }

        public Details MakeDetails(
            string phoneNumber,
            string mailAddress,
            string physicalAddress,
            string zipCode,
            string city
        )
        {
            return new Details(
                phoneNumber,
                mailAddress,
                physicalAddress,
                zipCode,
                city
            );
        }

        public Storekeeper MakeStorekeeper(
            string firstName,
            string lastName,
            string matricule,
            string login,
            string password,
            DateTime startDate,
            Details details
        )
        {
            return new Storekeeper(
                firstName,
                lastName,
                matricule,
                login,
                password,
                startDate,
                details
            );
        }

        public Cashier MakeCashier(
            string firstName,
            string lastName,
            string matricule,
            string login,
            DateTime startDate,
            Details details
        )
        {
            return new Cashier(
                firstName,
                lastName,
                matricule,
                login,
                startDate,
                details
            );
        }
    }
}