using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;
using OlympicGames.Utils;

namespace OlympicGames.Olympics.Models
{
    public class Boxer : Olympian, IBoxer
    {
        private BoxingCategory boxingCategory;
        private int wins;
        private int losses;

        public Boxer(string firstName, string lastName, string country, string boxingCategory, int wins, int losses) : base(firstName, lastName, country)
        {
            switch (boxingCategory)
            {
                case "Flyweight":
                    this.Category = BoxingCategory.Flyweight;
                    break;
                case "Featherweight":
                    this.Category = BoxingCategory.Featherweight;
                    break;
                case "Lightweight":
                    this.Category = BoxingCategory.Lightweight;
                    break;
                case "Middleweight":
                    this.Category = BoxingCategory.Middleweight;
                    break;
                case "Heavyweight":
                    this.Category = BoxingCategory.Heavyweight;
                    break;
            }
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
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxNumber(value, 0, 100);
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
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxNumber(value, 0, 100);
                this.losses = value;
            }
        }
        public override string ToString()
        {
            return string.Format("BOXER: " + FirstName + " " + LastName + "from " + Country + "\n" + "Category: " + Category +
            "\nWins: " + Wins + "\nLosses: " + Losses);
        }
    }
}
