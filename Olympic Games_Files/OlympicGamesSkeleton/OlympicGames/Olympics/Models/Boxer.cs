using System;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;

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

            }
        }
    }
}
