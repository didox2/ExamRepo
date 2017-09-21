using Traveller.Models.Contracts;

namespace Traveller.Models
{
    public class Ticket : ITicket
    {
        private IJourney journey;
        private decimal administrativeCosts;

        public Ticket(IJourney journey, decimal administrativeCosts)
        {
            this.Journey = journey;
            this.AdministrativeCosts = administrativeCosts;
        }

        public decimal AdministrativeCosts
        {
            get
            {
                return this.administrativeCosts;
            }
            set
            {
                this.administrativeCosts = value;
            }
        }

        public IJourney Journey
        {
            get
            {
                return this.journey;
            }
            set
            {
                this.journey = value;
            }
        }

        public decimal CalculatePrice()
        {
            return this.AdministrativeCosts + this.Journey.CalculateTravelCosts();
        }

        public override string ToString()
        {
            return string.Format($"Ticket ----\nDestination: {this.Journey.Destination}\nPrice: {this.CalculatePrice()}");
        }
    }
}
