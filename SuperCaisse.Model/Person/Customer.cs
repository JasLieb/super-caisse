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
        { }

        public void SendMailRegistrationSuccessed()
        {
            Console.WriteLine($"Registration success mail was send to {Name}");
        }

        public void SendMailWebOrderCompleted(WebOrder webOrder)
        {
            Console.WriteLine($"Web ordering with {webOrder.DeliveryMode} delivery mode successfull mail was send to {Name}");
        }
    }
}