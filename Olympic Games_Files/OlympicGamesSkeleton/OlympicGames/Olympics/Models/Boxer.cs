using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;
using OlympicGames.Utils;
using System.Text;
using System;

namespace OlympicGames.Olympics.Models
{
    public class Boxer : Olympian, IBoxer
    {
        private BoxingCategory boxingCategory;
        private int wins;
        private int losses;

        public Boxer(string firstName, string lastName, string country, string boxingCategory, int wins, int losses)
            : base(firstName, lastName, country)
        {
            Enum.TryParse(boxingCategory, true, out this.boxingCategory);
            this.Wins = wins;
            this.Losses = losses;
        }

        public BoxingCategory Category
        {
            get
            {
                return this.boxingCategory;
            }
            private set
            {
                this.boxingCategory = value;
            }
        }
        public int Wins
        {
            get
            {
                return this.wins;
            }
            private set
            {
                Validator.ValidateMinAndMaxNumber(value, 0, 100, "Wins must be between 0 and 100!");
                this.wins = value;
            }
        }

        public int Losses
        {
            get
            {
                return this.losses;
            }
            private set
            {
                Validator.ValidateMinAndMaxNumber(value, 0, 100, "Losses must be between 0 and 100!");
                this.losses = value;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Category: " + this.Category + "\nWins: " + this.Wins + "\nLosses: " + this.Losses));
            return sb.ToString();
        }

        protected override string GetTypeName()
        {
            return "Boxer";
        }
    }
}
