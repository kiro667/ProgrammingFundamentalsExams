using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> nameAndPoints = new Dictionary<string, int>();
            Dictionary<string, int> languageAndCount = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }
                string[] data = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 2) //когато има banned
                {
                    string user = data[0];
                    if (nameAndPoints.ContainsKey(user))
                    {
                        nameAndPoints.Remove(user);
                    }
                }
                else
                {
                    string user = data[0];
                    string language = data[1];
                    int points = int.Parse(data[2]);

                    if (!languageAndCount.ContainsKey(language))
                    {
                        languageAndCount.Add(language, 1);
                    }
                    else
                    {
                        languageAndCount[language]++;//obnovqvam (prebroqvam) stoinostta primerno ako ima tozi
                        //ezik edin put stoinostta 6te stane 2
                    }

                    if (nameAndPoints.ContainsKey(user))
                    {
                        if (points > nameAndPoints[user])
                        {
                            nameAndPoints[user] = points;
                        }
                    }
                    else
                    {
                        nameAndPoints.Add(user, points);
                    }
                }
            }
            Console.WriteLine("Results:");
            foreach (var item in nameAndPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {

                Console.WriteLine($"{item.Key} | {item.Value}");

            }
            Console.WriteLine("Submissions:");
            foreach (var item1 in languageAndCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item1.Key} - {item1.Value}");
            }
        }
    }
}
