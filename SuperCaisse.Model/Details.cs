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
            PhysicalAddress = physicalAddress;
            ZipCode = zipCode;
            City = city;
        }

        public string PhoneNumber { get; }
        public string MailAddress { get; }
        public string PhysicalAddress { get; }
        public string ZipCode { get; }
        public string City { get; }
    }
}