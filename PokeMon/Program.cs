using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            int izv = N;
            int divide = 0;
            int count = 0;
            while (izv >= M)
            {
                izv -= M;
                count++;

                if (izv == 0.5 * N && Y != 0)
                {
                    izv /= Y;
                }
            }
            Console.WriteLine(izv);
            Console.WriteLine(count);
        }
    }
}
