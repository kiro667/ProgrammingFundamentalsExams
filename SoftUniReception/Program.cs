using System;

namespace SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int employee1 = int.Parse(Console.ReadLine());
            int employee2 = int.Parse(Console.ReadLine());
            int employee3 = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int studentsPerHour = employee1 + employee2 + employee3;

            int hours = 0;


            while (studentsCount > 0)

            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }
                else
                {

                    studentsCount -= studentsPerHour;
                }

            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
