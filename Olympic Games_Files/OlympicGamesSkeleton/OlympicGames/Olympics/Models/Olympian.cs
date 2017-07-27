using System;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Olympics.Models
{
    public class Olympian : IOlympian, ICountry
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
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxLength(value, 2, 20);
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
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxLength(value, 2, 20);
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
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxLength(value, 3, 25);
                this.country = value;
            }
        }
        
    }
}
