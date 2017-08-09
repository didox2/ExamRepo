using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Olympics.Models
{
    public abstract class Olympian : IOlympian
    {
        private string firstName;
        private string lastName;
        private string country;

        public Olympian(string firstName, string lastName, string country)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Validator.ValidateMinAndMaxLength(value, 2, 20, "First name must be between 2 and 20 characters long!");
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Validator.ValidateMinAndMaxLength(value, 2, 20, "Last name must be between 2 and 20 characters long!");
                this.lastName = value;
            }
        }
        public string Country
        {
            get
            {
                return this.country;
            }
            private set
            {
                Validator.ValidateMinAndMaxLength(value, 3, 25, "Country must be between 3 and 25 characters long!");
                this.country = value;
            }
        }
        public override string ToString()
        {
            return string.Format(this.GetTypeName().ToUpper() + ": " + this.FirstName + " " + this.LastName + " from " +
                this.Country + "\n" + this.PrintAdditionalInfo());
        }

        protected abstract string PrintAdditionalInfo();

        protected abstract string GetTypeName();


    }
}
