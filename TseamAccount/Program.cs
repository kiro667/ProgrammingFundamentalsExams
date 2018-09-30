using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Regex starReg = new Regex(@"[sSTtaArR]");
            Regex messageReg = new Regex(@"[^@\-:!>]*@(?<name>[A-Za-z]+)[^@\-:!>]*:(\d+)[^@\-:!>]*!(?<type>A|D)![^@\-:!>]*->(\d+)[^@\-:!>]*");
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                MatchCollection starMatches = starReg.Matches(line);
                int step = starMatches.Count;
                StringBuilder decMessage = new StringBuilder();


                for (int j = 0; j < line.Length; j++)
                {
                    char current = (char)(line[j] - step);
                    decMessage.Append(current);
                }

                if (messageReg.IsMatch(decMessage.ToString()))
                {
                    Match match = messageReg.Match(decMessage.ToString());
                    string type = match.Groups["type"].Value;
                    string name = match.Groups["name"].Value;
                    if (type == "D")
                    {
                        destroyed.Add(name);
                    }
                    else if (type == "A")
                    {
                        attacked.Add(name);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (string planet in attacked.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (string planet in destroyed.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
