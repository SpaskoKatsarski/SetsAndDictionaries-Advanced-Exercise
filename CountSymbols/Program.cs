using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            foreach (char letter in input)
            {
                if (!occurrences.ContainsKey(letter))
                {
                    occurrences.Add(letter, 0);
                }

                occurrences[letter]++;
            }

            foreach (var kvp in occurrences.OrderBy(m => m.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
