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
    }
}