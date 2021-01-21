namespace SuperCaisse.Model
{
    public class Address
    {
        public Address(string physicalAddress, string zipCode, string city)
        {
            PhysicalAddress = physicalAddress;
            ZipCode = zipCode;
            City = city;
        }

        public string PhysicalAddress { get; }
        public string ZipCode { get; }
        public string City { get; }
    }
}