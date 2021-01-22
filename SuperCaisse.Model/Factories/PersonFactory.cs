using System;

namespace SuperCaisse.Model
{
    public static class PersonFactory
    {
        public static Customer MakeCustomer(
            string name, 
            Details details, 
            string password
        )
        {
            return new Customer(
                name,
                details,
                password
            );
        }

        public static Details MakeDetails(
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

        public static Provider MakeProvider(
            string name, 
            Details details, 
            Catalog catalog
        )
        {
            return new Provider(
                name,
                details,
                catalog
            );
        }

        public static Storekeeper MakeStorekeeper(
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

        public static Cashier MakeCashier(
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