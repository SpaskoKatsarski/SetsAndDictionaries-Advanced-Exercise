using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    internal class Program
    {
        class Follows
        {
            public Follows()
            {
                this.Followers = new List<string>();
                this.Following = new List<string>();
            }

            public List<string> Followers { get; set; }

            public List<string> Following { get; set; }
        }

        static void Main(string[] args)
        {
            //Dictionary<string, List<string>> followers = new Dictionary<string, List<string>>();

            //Dictionary<string, List<string>> following = new Dictionary<string, List<string>>();

            Dictionary<string, Follows> vloggers = new Dictionary<string, Follows>();

            string command;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string vlogerName = cmdArgs[0];

                if (cmdArgs[1] == "joined")
                {
                    if (!vloggers.ContainsKey(vlogerName))
                    {
                        vloggers.Add(vlogerName, new Follows());
                    }
                }
                else if (cmdArgs[1] == "followed")
                {
                    string secondVloger = cmdArgs[2];

                    if (vloggers.ContainsKey(vlogerName) && vloggers.ContainsKey(secondVloger) && vlogerName != secondVloger)
                    {
                        //firstVloger starts following secondVloger
                        //Check if the firstVloger already follows the secondVloger
                        if (!vloggers[secondVloger].Followers.Contains(vlogerName))
                        {
                            vloggers[vlogerName].Following.Add(secondVloger);
                            //secondVloger gains a follower (firstVloger)
                            vloggers[secondVloger].Followers.Add(vlogerName);
                        }
                    }
                }

            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            //Get the most famous vlogger and print the information about him:
            //1.VenomTheDoctor : 2 followers, 0 following
            //* EmilConrad
            //*Saffrona

            int position = 1;

            string mostFollowed = vloggers.OrderByDescending(v => v.Value.Followers.Count).ThenBy(v => v.Value.Following.Count).First().Key;
            Console.WriteLine($"{position}. {mostFollowed} : {vloggers[mostFollowed].Followers.Count} followers, {vloggers[mostFollowed].Following.Count} following");

            foreach (string follower in vloggers[mostFollowed].Followers.OrderBy(f => f))
            {
                Console.WriteLine($"*  {follower}");
            }

            foreach (var vlogger in vloggers.OrderByDescending(v => v.Value.Followers.Count).ThenBy(v => v.Value.Following.Count))
            {
                if (vlogger.Key == mostFollowed)
                    continue;

                Console.WriteLine($"{++position}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
            }
        }
    }
}
