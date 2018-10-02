using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightSabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            int c = 0;

            for (int i = 1; i <= countOfStudents; i++)
            {
                if (i % 6 == 0)
                {
                    c++;
                }
            }
            double money = priceOfLightSabers * (countOfStudents + (int)Math.Ceiling(0.1 * countOfStudents)) + priceOfRobes * countOfStudents +
                priceOfBelts * (countOfStudents - c);
            if (money <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {money:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {money - amountOfMoney:f2}lv more.");
            }
        }
    }
}
