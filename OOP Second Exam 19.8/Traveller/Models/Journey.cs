﻿using System;
using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models
{
    public class Journey : IJourney
    {
        private string startLocation;
        private string destination;
        private int distance;
        private IVehicle vehicle;

        public Journey(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            this.StartLocation = startLocation;
            this.Destination = destination;
            this.Distance = distance;
            this.Vehicle = vehicle;
        }

        public string Destination
        {
            get
            {
                return this.destination;
            }
            set
            {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("The Destination's length cannot be less than 5 or more than 25 symbols long.");
                }
                this.destination = value;
            }
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
            set
            {
                if (value < 5 || value > 5000)
                {
                    throw new ArgumentOutOfRangeException("The Distance cannot be less than 5 or more than 5000 kilometers.");
                }
                this.distance = value;
            }
        }

        public string StartLocation
        {
            get
            {
                return this.startLocation;
            }
            set
            {
                if (value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("The StartingLocation's length cannot be less than 5 or more than 25 symbols long.");
                }
                this.startLocation = value;
            }
        }

        public IVehicle Vehicle
        {
            get
            {
                return this.vehicle;
            }
            set
            {
                this.vehicle = value;
            }
        }

        public decimal CalculateTravelCosts()
        {
            return this.Vehicle.PricePerKilometer * this.Distance;
        }

        public override string ToString()
        {
            return string.Format($"Journey ----\nStart location: {this.StartLocation}\nDestination: {this.Destination}\nDistance: {this.Distance}" +
            $"\nVehicle type: {this.Vehicle.Type}\nTravel costs: {this.CalculateTravelCosts()}");
        }
    }
}
