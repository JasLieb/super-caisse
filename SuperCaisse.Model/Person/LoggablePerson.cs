namespace SuperCaisse.Model
{
    public abstract class LoggablePerson : Person
    {
        public string Password { get; }

        protected LoggablePerson(
            string name,
            Details details,
            string password
        ) : base(name, details)
        {
            Password = password;
        }
    }
}