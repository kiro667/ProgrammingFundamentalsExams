using System;

namespace AnonymousDownsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int down = int.Parse(Console.ReadLine());
            int key = int.Parse(Console.ReadLine());
            decimal calc = 0;
            decimal sum = 0;
            for (int i = 0; i < down; i++)
            {
                string[] input = Console.ReadLine().Split();

                string site = input[0];
                decimal visits = decimal.Parse(input[1]);
                decimal priceper1 = decimal.Parse(input[2]);
                calc = visits * priceper1;
                sum += calc;
                Console.WriteLine(site);
            }
            Console.WriteLine($"Total Loss: {sum:F20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(key, down)}");
        }
    }
}
