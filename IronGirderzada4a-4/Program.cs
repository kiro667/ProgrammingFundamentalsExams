using System;
using System.Collections.Generic;
using System.Linq;

namespace IronGirderzada4a_4
{
    class Program
    {
        static void Main(string[] args)
        {
                Dictionary<string, KeyValuePair<int, int>> allCities = new Dictionary<string, KeyValuePair<int, int>>();
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "Slide rule")
                    {
                        break;
                    }
                    var tokens = input.Split(new[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries);
                    var city = tokens[0];
                    var populationCount = int.Parse(tokens[2]);

                    if (tokens[1].Equals("ambush"))
                    {
                        if (allCities.ContainsKey(city))
                        {
                            var currentCount = allCities[city].Value;//tova ne6to mi e 3-toto
                                                                     //toest broikata na putnicite
                            currentCount -= populationCount;
                            if (currentCount < 0)
                            {
                                currentCount = 0;
                            }
                            allCities[city] = new KeyValuePair<int, int>(0, currentCount);
                        }
                    }
                    else
                    {
                        var time = int.Parse(tokens[1]);
                        if (!allCities.ContainsKey(city))
                        {
                            allCities.Add(city, new KeyValuePair<int, int>(time, populationCount));
                        }
                        else//ako ve4e go ima gradut
                        {
                            var currentCount = allCities[city].Value;//tova mi e 3-toto
                                                                     //toest tova e stoinostta na to4niq grad 
                            var currentTime = allCities[city].Key;//tova mi e 2-to
                            currentCount += populationCount;//kum stoinostta na to4niq 
                                                            //grad pribavqm drugite stoinosti na toq grad

                            if (currentTime == 0 || currentTime > time)
                            {
                                currentTime = time;
                            }

                            allCities[city] = new KeyValuePair<int, int>(currentTime, currentCount);
                        }
                    }
                }

                foreach (var city in allCities.OrderBy(x => x.Value.Key).ThenBy(x => x.Key))
                {
                    if (allCities[city.Key].Key == 0 || allCities[city.Key].Value <= 0)
                    {
                        continue;
                    }
                    Console.WriteLine($"{city.Key} -> Time: {city.Value.Key} -> Passengers: {city.Value.Value}");
                }
        }
    }
}
