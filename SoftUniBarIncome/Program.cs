using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> lessons =
                Console.ReadLine().
                Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Play!")
                {
                    break;
                }
                string[] data =
                    input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Install")
                {
                    if (!lessons.Contains(data[1]))
                    {
                        lessons.Add(data[1]);
                    }
                }
                else if (data[0] == "Uninstall")
                {
                    if (lessons.Contains(data[1]))
                    {
                        int remove = lessons.IndexOf(data[1]);
                        lessons.RemoveAt(remove);
                    }
                }
                else if (data[0] == "Update")
                {
                    int update = lessons.IndexOf(data[1]);
                    if (update + 1 < lessons.Count && update >= 0)
                    {


                        lessons.RemoveAt(update);
                        lessons.Add(data[1]);
                    }
                }
                else if (data[0] == "Expansion")
                {
                    string[] data1 = data[1]
                        .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    if (lessons.Contains(data1[0]))
                    {
                        int expansion = lessons.IndexOf(data1[0]);
                        if (expansion + 1 >= 0 && expansion < lessons.Count - 1)
                        {
                            lessons.Insert(expansion + 1, $"{data1[0]}:{data1[1]}");
                        }
                        //lessons.Add($"{data1[0]}:{data1[1]}");
                    }


                }


            }
            Console.WriteLine(string.Join(" ", lessons));
        }
    }
}
