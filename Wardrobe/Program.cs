using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];

                for (int j = 0; j < input.Length - 3; j++)
                {
                    string currItem = input[i + 2];

                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());
                    }

                    if (!wardrobe[color].ContainsKey(currItem))
                    {
                        wardrobe[color].Add(currItem, 0);
                    }

                    wardrobe[color][currItem]++;
                }
            }

            string[] searchedItem = Console.ReadLine().Split();

            string colorToSearchFor = searchedItem[0];
            string dress = searchedItem[1];

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var kvp2 in kvp.Value)
                {
                    Console.Write($"* {kvp2.Key} - {kvp2.Value}");

                    if (kvp.Key == colorToSearchFor && kvp2.Key == dress)
                    {
                        Console.WriteLine(" (found!)");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
