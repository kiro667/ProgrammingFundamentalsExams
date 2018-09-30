using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {//da ne ma4va bukvi ili cifri sled tova ^ i tuka si e teksta $


            //da ne ma4va bukvi ili cifri sled tova ^ i tuka si e teksta $ tezi ograni4iteli gi slagame za6toto ni e daden formata

            Regex surface = new Regex(@"^[^A-Za-z0-9]+$");
            Regex mantle = new Regex(@"^[0-9_]+$");
            Regex middle = new Regex(@"^[^A-Za-z0-9]+[0-9_]+(?<core>[A-Za-z]+)[0-9_]+[^A-Za-z0-9]+$");
            //
            int length = 0;

            for (int i = 0; i < 5; i++)
            {
                string line = Console.ReadLine();

                if (i == 0 || i == 4)
                {

                    Validate(surface, line);
                }
                else if (i == 1 || i == 3)
                {
                    Validate(mantle, line);
                }
                else
                {
                    Validate(middle, line);
                    Match match = middle.Match(line);
                    length = match.Groups["core"].Length;//moje i ["core"].Value
                }

            }
            Console.WriteLine("Valid");
            Console.WriteLine(length);
        }

        private static void Validate(Regex regex, string line)
        {
            if (regex.IsMatch(line) == false)
            {
                Console.WriteLine("Invalid");
                //poneje sme v metod toi 6te izleze ot tozi metod zatova
                Environment.Exit(0);//ina4e stava i s return;
            }
        }
    }
}
