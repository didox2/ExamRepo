using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp
{
    public class Task3
    {
        public static void Run()
        {
            LinkedList<int> personsID = new LinkedList<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                int next = 0;

                switch (command)
                {
                    case "add":

                        int iD = int.Parse(input[1]);
                        personsID.AddFirst(iD);
                        Console.WriteLine("Added {0}", iD);

                        break;

                    case "slide":

                        int k = int.Parse(input[1]) % (personsID.Count);

                        for (int j = 0; j < k; j++)
                        {
                            next = personsID.Last.Value;
                            personsID.RemoveLast();
                            personsID.AddFirst(next);
                        }

                        Console.WriteLine("Slided {0}", int.Parse(input[1]));

                        break;
                    case "print":

                        StringBuilder sb = new StringBuilder();

                        var current = personsID.First;

                        while (current != null)
                        {
                            sb.Append(current.Value + " ");
                            current = current.Next;
                        }

                        string result = sb.ToString().TrimEnd(' ');
                        Console.WriteLine(result);

                        break;
                }
            }
        }
    }
}