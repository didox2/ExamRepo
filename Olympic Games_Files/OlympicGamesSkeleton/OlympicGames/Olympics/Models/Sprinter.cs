using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlympicGames.Olympics.Models
{
    public class Sprinter : Olympian, ISprinter
    {
        private IDictionary<string, double> personalRecords;

        public Sprinter(string firstName, string lastName, string country, IDictionary<string, double> personalRecords = null) 
            : base(firstName, lastName, country)
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
                this.personalRecords = value;
            }
        }

        protected override string GetTypeName()
        {
            return "Sprinter";
        }

        protected override string PrintAdditionalInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(PersonalRecords != null ? GlobalConstants.PersonalRecords + "\n" + 
                string.Join("\n", this.PersonalRecords.Select(x => string.Format($"{x.Key}m: { x.Value:0.##}s"))) : GlobalConstants.NoPersonalRecordsSet));
            return sb.ToString();
        }
    }
}
