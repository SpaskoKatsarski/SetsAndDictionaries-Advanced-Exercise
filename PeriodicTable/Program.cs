using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] chemicalCompound = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < chemicalCompound.Length; j++)
                {
                    set.Add(chemicalCompound[j]);
                }
            }

            Console.WriteLine(string.Join(' ', set.OrderBy(c => c))); // or SortedSet<string>
        }
    }
}
