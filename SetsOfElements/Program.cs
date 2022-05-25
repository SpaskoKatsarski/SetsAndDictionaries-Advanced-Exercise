using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstLength = arr[0];
            int secondLength = arr[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstLength; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < secondLength; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(' ', firstSet));

            //List<int> matchingElements = new List<int>() { 2, 3, 4};

            //foreach (var num in firstSet)
            //{
            //    foreach (var num2 in secondSet)
            //    {
            //        if (num == num2)
            //        {
            //            matchingElements.Add(num);
            //        }
            //    }
            //}

            //Console.WriteLine(string.Join(" ", matchingElements));
        }
    }
}
