using System;

namespace SuperCaisse.Model
{
    public class Customer : LoggablePerson
    {
        public Customer(
            string name, 
            Details details, 
            string password
        ) : base(name, details, password)
        {
        }

        public void SendMailRegistrationSuccessed()
        {
            Console.WriteLine($"Registration success mail was send to {Name}");
        }
    }
}