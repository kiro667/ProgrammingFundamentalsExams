using System;
using System.Numerics;

namespace _01._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {

            int snowBallNumbers = int.Parse(Console.ReadLine());

            BigInteger snowBallValue = 0;
            BigInteger max = 0;

            string output = "";

            for (int i = 1; i <= snowBallNumbers; i++)
            {
                int snowBallSnow = int.Parse(Console.ReadLine());
                int snowBallTime = int.Parse(Console.ReadLine());
                int snowBallQuality = int.Parse(Console.ReadLine());



                snowBallValue = BigInteger.Pow(snowBallSnow / snowBallTime, snowBallQuality);
                if (snowBallValue >= max)
                {
                    max = snowBallValue;
                    output = $"{snowBallSnow} : {snowBallTime} = {snowBallValue} ({snowBallQuality})";
                }
            }
            Console.WriteLine(output);
        }
    }
}
