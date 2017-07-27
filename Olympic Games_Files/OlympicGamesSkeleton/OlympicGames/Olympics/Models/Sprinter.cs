using System;
using System.Collections.Generic;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Olympics.Models
{
    public class Sprinter : Olympian, ISprinter
    {
        private IDictionary<string, double> personalRecords;

        public Sprinter(string firstName, string lastName, string country, IDictionary<string,double> personalRecords) : base(firstName, lastName, country)
        {
            this.PersonalRecords = personalRecords;
        }

        public IDictionary<string, double> PersonalRecords
        {
            get
            {
                return this.personalRecords;
            }
            private set
            {
                
            }
        }
    }
}
