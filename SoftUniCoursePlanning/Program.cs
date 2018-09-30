using System;

namespace ConsoleApp90
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 0;

            string all = "";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Visual Studio crash")
                {
                    break;
                }

                all += input + " ";


            }

            string[] data = all.Split();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == "32656" &&
                    data[i + 1] == "19759" &&
                    data[i + 2] == "32763")
                {
                    length = int.Parse(data[i + 4]);
                    string word = "";//!!!!slaga se tuk string word = "";
                    //za6toto 6te dobavq kum ve4e razpe4atanoto
                    for (int j = 0; j < length; j++)
                    {
                        word += (char)(int.Parse((data[i + 6 + j])));

                    }
                    Console.WriteLine(word);

                }

            }


        }
    }
}
