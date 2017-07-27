using System;
using OlympicGames.Olympics.Contracts;

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

            }
        }

    }
}
