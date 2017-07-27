using System;
using System.Collections.Generic;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System.Linq;

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
                Validator.ValidateIfNull(value, GlobalConstants.NoPersonalRecordsSet);
                this.personalRecords = value;
            }
        }
        public override string ToString()
        {
            return string.Format("SPRINTER: " + FirstName + " " + LastName + "from " + Country + "\n" + 
                PersonalRecords != null ? GlobalConstants.PersonalRecords +string.Join("\n", 
                PersonalRecords.Select(x=> $"{x.Key}m: {x.Value:F2}s")): GlobalConstants.NoPersonalRecordsSet);
        }
    }
}
