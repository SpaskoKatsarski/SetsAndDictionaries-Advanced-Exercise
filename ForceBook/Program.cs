using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceSides = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                //{forceSide} | {forceUser}
                //{forceUser} -> {forceSide}
                string[] tokens = input.Split(new string[] { " -> ", " | " }, StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains("|"))
                {
                    string currForceSide = tokens[0];
                    string user = tokens[1];

                    if (!forceSides.ContainsKey(currForceSide))
                    {
                        forceSides.Add(currForceSide, new List<string>());
                    }

                    if (!forceSides[currForceSide].Contains(user))
                    {
                        forceSides[currForceSide].Add(user);
                    }
                }
                else if (input.Contains("->"))
                {
                    string user = tokens[0];
                    string currForceSide = tokens[1];

                    if (!forceSides.ContainsKey(currForceSide))
                    {
                        forceSides.Add(currForceSide, new List<string>());
                    }

                    if (forceSides.Any(x => x.Value.Contains(user)))
                    {
                        string movingMember = user;

                        List<string> modifiedSide = new List<string>();

                        string sideOfMover = string.Empty;

                        foreach (var kvp in forceSides)
                        {
                            List<string> memberList = kvp.Value;

                            if (memberList.Contains(user))
                            {
                                modifiedSide = memberList;
                                break;
                            }
                        }

                        modifiedSide.Remove(user);

                        forceSides[sideOfMover] = modifiedSide;
                    }

                    forceSides[currForceSide].Add(user);

                    Console.WriteLine($"{user} joins the {currForceSide} side!");
                }

                input = Console.ReadLine();
            }

            foreach (var side in forceSides.OrderByDescending(s => s.Value.Count).ThenBy(s => s.Key))
            {
                if (side.Value.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                foreach (var member in side.Value.OrderBy(m => m))
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}
