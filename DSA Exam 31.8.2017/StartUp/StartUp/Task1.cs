using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace StartUp
{
    public class Task1
    {
        public static void Run()
        {
            Dictionary<string, BigList<Order>> consumerToOrderMap = new Dictionary<string, BigList<Order>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string command = input.Split()[0];

                switch (command)
                {
                    case "AddOrder":

                        string[] parameters = input.Split(';');
                        string consumer = parameters[2];

                        if (!consumerToOrderMap.ContainsKey(consumer))
                        {
                            consumerToOrderMap.Add(consumer, new BigList<Order>());
                        }

                        string name = string.Join(" ", parameters[0].Split().Skip(1).ToArray());
                        decimal price = decimal.Parse(parameters[1]);
                        Order order = new Order(name, price, consumer);
                        consumerToOrderMap[consumer].Add(order);
                        Console.WriteLine("Order added");

                        break;

                    case "DeleteOrders":

                        string consumerToDelete = string.Join(" ", input.Split(';')[0].Split().Skip(1).ToArray());

                        if (consumerToOrderMap.ContainsKey(consumerToDelete))
                        {
                            int counter = consumerToOrderMap[consumerToDelete].Count();
                            consumerToOrderMap.Remove(consumerToDelete);
                            Console.WriteLine("{0} orders deleted", counter);
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }

                        break;

                    case "FindOrdersByPriceRange":

                        decimal min = decimal.Parse(input.Split()[1].Split(';')[0].ToString());
                        decimal max = decimal.Parse(input.Split()[1].Split(';')[1].ToString());

                        List<Order> list = new List<Order>();

                        foreach (string ordType in consumerToOrderMap.Keys)
                        {
                            foreach (var val in consumerToOrderMap[ordType])
                            {
                                if (val.Price >= min && val.Price <= max)
                                {
                                    list.Add(val);
                                }
                            }
                        }

                        if (list.Count != 0)
                        {
                            Console.WriteLine(string.Join("\n", list.OrderBy(x => x.Name)));
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }

                        break;

                    case "FindOrdersByConsumer":

                        string consumerName = string.Join(" ", input.Split().Skip(1).ToArray());

                        List<Order> foundedConsumers = new List<Order>();

                        if (consumerToOrderMap.ContainsKey(consumerName))
                        {
                            consumerToOrderMap[consumerName].ForEach(x => foundedConsumers.Add(x));

                            Console.WriteLine(string.Join("\n", foundedConsumers.OrderBy(x => x.Name)));
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }

                        break;
                }
            }
        }
    }

    public class Order
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Consumer { get; set; }

        public Order(string name, decimal price, string consumer)
        {
            this.Name = name;
            this.Price = price;
            this.Consumer = consumer;
        }

        public override string ToString()
        {
            return String.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Consumer, this.Price);
        }
    }
}