using System;
using System.Collections.Generic;
using System.Linq;//vmest grains e Value

namespace zada4a2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> seq = Console.ReadLine().Split().
                Select(int.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Mort")
                {
                    break;
                }
                string[] data = input.Split();
                string command = data[0];

                if (command == "Add")
                {
                    int numb = int.Parse(data[1]);
                    seq.Add(numb);
                }
                else if (command == "Remove")
                {
                    int numb = int.Parse(data[1]);

                    if (seq.Contains(numb))//числото може да не е валиден индекс,
                                           //но да се садържа в поредицата
                    {
                        int index1 = seq.IndexOf(numb);
                        seq.RemoveAt(index1);//няма нужда от допълнителна проверка.
                                             //за да влезе до тук значи числото е част от поредицата

                    }
                    else
                    {
                        int index = numb;
                        if (index >= 0 && index < seq.Count)
                        {
                            seq.RemoveAt(index);//махаме само ако е валиден индекс
                        }
                    }
                }
                else if (command == "Replace")
                {
                    int value = int.Parse(data[1]);
                    int replacement = int.Parse(data[2]);

                    if (seq.Contains(value))//тази проверка ти гарантира валиден индекс
                    {
                        int index1 = seq.IndexOf(value);
                        seq.RemoveAt(index1);
                        seq.Insert(index1, replacement);
                    }


                }
                else if (command == "Increase")
                {
                    int value = int.Parse(data[1]);
                    //пише да се намери първата стойност която не е по малка от value.
                    //ти правиш точна проверка
                    List<int> bigger = seq.Where(x => x >= value).ToList();
                    //вземаме всички които са по големи или равни на value
                    if (bigger.Count > 0)//имаме числа които отговарят на критерия
                    {
                        int needed = bigger.First();//връща първия елемент
                        for (int i = 0; i < seq.Count; i++)
                        {
                            seq[i] += needed;

                        }
                    }
                    else
                    {
                        int needed = seq.Last();//връща последния елемент
                        for (int i = 0; i < seq.Count; i++)
                        {
                            seq[i] += needed;

                        }
                    }

                }
                else if (command == "Collapse")
                {
                    int value = int.Parse(data[1]);
                    seq = seq.Where(x => x >= value).ToList();
                    //връща стойностите които са по големи или равни на value
                }
            }

            Console.WriteLine(string.Join(" ", seq));

        }
    }
}