using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex regex = new Regex(@"^\%(?<customer>[A-Z][a-z]+)\%[^|$%.]*?\<(?<product>[\w]+)\>[^|$%.]*?\|(?<count>[\d]+)\|[^|$%.]*?(?<price>[\d]+\.?[\d]+)\$[^|$%.]*?$");
            double totalIncome = 0.0;
            string output = "";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of shift")
                {
                    break;
                }
                Match match = regex.Match(input);

                if (regex.IsMatch(input))
                {

                    string customers = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double totalPrice = count * price;
                    Console.WriteLine($"{customers}: {product} - {totalPrice:F2}");
                    totalIncome += totalPrice;

                }


            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
