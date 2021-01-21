namespace SuperCaisse.Model
{
    public class Details 
    {
        public Details(
            string phoneNumber, 
            string mailAddress, 
            string physicalAddress, 
            string zipCode, 
            string city
        )
        {
            PhoneNumber = phoneNumber;
            MailAddress = mailAddress;
            PhysicalAddress = new Address(
                physicalAddress,
                zipCode,
                city
            );
        }

        public string PhoneNumber { get; }
        public string MailAddress { get; }
        public Address PhysicalAddress { get; }
    }
}