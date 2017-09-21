using System;

namespace Traveller.Utils
{
    public static class Validator
    {
        public static void ValidateMinAndMaxCapacity(this int value, int min, int max, string vehicleType)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(string.Format("A {0} cannot have less than {1} passengers or more than {2} passengers.", 
                    vehicleType, min, max));
            }
        }
        public static void ValidateMinAndMaxPriceCapacity(this decimal value, decimal min, decimal max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(string.Format("A vehicle with a price per kilometer lower than ${0:F2} or higher than ${1:F2} cannot exist!",
                     min, max));
            }
        }

        internal static void ValidateMinAndMaxCarst(this int value, int minCarts, int maxCarts, string type)
        {
            if (value < minCarts || value > maxCarts)
            {
                throw new ArgumentOutOfRangeException(string.Format("A {0} cannot have less than {1} cart or more than {2} carts.",
                    type, minCarts, maxCarts));
            }
        }
    }
}
