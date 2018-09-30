using System;

namespace Hogswatchzad1
{
    class Program
    {
        static void Main(string[] args)
        {
            int homes = int.Parse(Console.ReadLine());
            int initialPresents = int.Parse(Console.ReadLine());
            int remainingPressents = initialPresents;
            int usedAdditionalPresents = 0;
            int trips = 0;

            for (int i = 1; i <= homes; i++)
            {
                int neededPresents = int.Parse(Console.ReadLine());
                if (remainingPressents - neededPresents < 0)//когато не стигат подаръците
                {
                    int additionalPresents = (initialPresents / i) * (homes - i) + (neededPresents - remainingPressents);
                    remainingPressents += additionalPresents;
                    usedAdditionalPresents += additionalPresents;
                    trips++;
                }

                remainingPressents -= neededPresents;
            }

            if (trips > 0)//ако е направил допълнителни разходки
            {
                Console.WriteLine(trips);
                Console.WriteLine(usedAdditionalPresents);
            }
            else
            {
                Console.WriteLine(remainingPressents);
            }
        }
    }
}
