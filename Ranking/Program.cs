using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] parts = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string currContest = parts[0];
                string currPass = parts[1];

                if (!contests.ContainsKey(currContest))
                {
                    contests.Add(currContest, currPass);
                }

                input = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();

            while (command != "end of submissions")
            {
                //{contest}=>{password}=>{username}=>{points}
                string[] parts = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = parts[0];
                string password = parts[1];
                string username = parts[2];
                int points = int.Parse(parts[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!candidates.ContainsKey(username))
                    {
                        candidates.Add(username, new Dictionary<string, int>());
                    }

                    if (!candidates[username].ContainsKey(contest))
                    {
                        candidates[username].Add(contest, 0);
                    }

                    //Part One Interview=>success=>Nikola=>120
                    if (points > candidates[username][contest])
                    {
                        candidates[username][contest] = points;
                    }
                }

                command = Console.ReadLine();
            }

            string user = candidates.OrderByDescending(c => c.Value.Values.Sum()).First().Key;
            int totalPoints = candidates.OrderByDescending(c => c.Value.Values.Sum()).First().Value.Values.Sum();

            Console.WriteLine($"Best candidate is {user} with total {totalPoints} points.");

            Console.WriteLine("Ranking:");

            foreach (var candidate in candidates.OrderBy(c => c.Key))
            {
                Console.WriteLine(candidate.Key);

                foreach (var contest in candidate.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
