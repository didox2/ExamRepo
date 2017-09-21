using System;
using System.Collections.Generic;

namespace StartUp
{
    public class Task4
    {
        public static void Run()
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            VeganMeal[] meals = new VeganMeal[n];
            List<VeganMeal> result = new List<VeganMeal>();
            List<VeganMeal> endResult = new List<VeganMeal>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                meals[i] = new VeganMeal(input[0], double.Parse(input[1]), double.Parse(input[2]));
                result.Add(meals[i]);
            }

            result.Sort();

            double currentCount = 0;
            double maximumProtein = 0;

            int counter = 0;

            for (int i = 0; i < n; i++)
            {

                currentCount += result[i].Weight;
                maximumProtein += result[i].Protein;
                counter++;
                endResult.Add(result[i]);

                if (currentCount > m)
                {
                    currentCount -= result[i].Weight;
                    maximumProtein -= result[i].Protein;
                    counter--;
                    endResult.Remove(result[i]);
                    break;
                }
            }

            Console.WriteLine(maximumProtein);

            for (int i = meals.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < endResult.Count; j++)
                {
                    if (meals[i] == endResult[j])
                    {
                        Console.WriteLine(endResult[j].Name);
                    }
                }
            }
        }
    }

    public class VeganMeal : IComparable<VeganMeal>
    {

        public VeganMeal(string name, double weight, double protein)
        {
            this.Name = name;
            this.Weight = weight;
            this.Protein = protein;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public double Protein { get; set; }

        public double DevidedIndex
        {
            get
            {
                return this.Weight / this.Protein;
            }
        }

        public int CompareTo(VeganMeal other)
        {
            return this.DevidedIndex.CompareTo(other.DevidedIndex);
        }

        public override string ToString()
        {
            return this.Name + " " + this.Weight + " " + this.Protein;
        }
    }
}
