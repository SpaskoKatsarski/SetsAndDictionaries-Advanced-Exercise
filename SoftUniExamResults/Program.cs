using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> studentes = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] cmdArgs = input.Split('-', StringSplitOptions.RemoveEmptyEntries);

                //Peter-Java-84
                string name = cmdArgs[0];
                string language = cmdArgs[1];

                if (language == "banned")
                {
                    if (studentes.ContainsKey(name))
                    {
                        studentes.Remove(name);
                    }

                    input = Console.ReadLine();

                    continue;
                }

                int points = int.Parse(cmdArgs[2]);

                if (!studentes.ContainsKey(name))
                {
                    studentes.Add(name, points);
                }

                if (!languages.ContainsKey(language))
                {
                    languages.Add(language, 0);
                }

                if (studentes[name] < points)
                {
                    studentes[name] = points;
                }

                languages[language]++;

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (KeyValuePair<string, int> student in studentes.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (KeyValuePair<string, int> language in languages.OrderBy(l => l.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
