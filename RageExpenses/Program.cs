using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int losts = int.Parse(Console.ReadLine());
            double headset = double.Parse(Console.ReadLine());
            double mouse = double.Parse(Console.ReadLine());
            double key = double.Parse(Console.ReadLine());
            double disp = double.Parse(Console.ReadLine());

            int h = 0;
            int m = 0;
            int k = 0;
            int d = 0;

            for (int i = 1; i <= losts; i++)
            {
                if (i % 2 == 0)
                {
                    h++;

                }
                if (i % 3 == 0)
                {
                    m++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    k++;
                    if (k % 2 == 0)
                    {
                        d++;
                    }
                }

            }

            Console.WriteLine($"Rage expenses: {(h * headset + m * mouse + k * key + d * disp):F2} lv.");


        }
    }
}
