using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            dict.Add("Spasko", new Dictionary<string, int>());
            dict["Spasko"].Add("InnerSpasko", 1);

            dict.Add("Vasko", new Dictionary<string, int>());
            dict["Vasko"].Add("InnerSpasko2", 3);

            dict.Add("Atanas", new Dictionary<string, int>());
            dict["Atanas"].Add("InnerSpasko3", 5);

            foreach (var item in dict.OrderBy(x => x.Value.OrderBy(y => y.Value)))
            {
                Console.WriteLine($"Key ({item.Key}) -> item {item.Value}");
            }
        }
    }
}
