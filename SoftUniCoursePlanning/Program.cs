using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)//Da pita na Swap  komandata dali ne moje da stane s Insert i remove
        {
            List<string> lessons = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string instruction = Console.ReadLine();
                if (instruction == "course start")
                {
                    break;
                }
                string[] command = instruction.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Add")
                {
                    if (!lessons.Contains(command[1]))
                    {
                        lessons.Add(command[1]);
                    }
                }
                else if (command[0] == "Insert")
                {
                    int insertIndex = int.Parse(command[2]);
                    if (!lessons.Contains(command[1]) && insertIndex >= 0 && insertIndex < lessons.Count)
                    {
                        lessons.Insert(insertIndex, command[1]);
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (lessons.Contains(command[1]) && lessons.Contains($"{command[1]}-Exercise"))
                    {
                        lessons.RemoveAt(lessons.IndexOf($"{command[1]}-Exercise"));
                        lessons.RemoveAt(lessons.IndexOf(command[1]));
                    }
                    else if (lessons.Contains(command[1]))
                    {
                        lessons.RemoveAt(lessons.IndexOf(command[1]));
                    }
                }

                else if (command[0] == "Swap")
                {

                    int index1 = lessons.IndexOf(command[1]);
                    int index2 = lessons.IndexOf(command[2]);


                    if (index1 >= 0 && index2 >= 0 && index1 < lessons.Count && index2 < lessons.Count)
                    {
                        lessons[index1] = command[2];
                        lessons[index2] = command[1];


                        if (index1 + 1 >= 0 && index1 + 1 < lessons.Count && lessons[index1 + 1] == $"{command[1]}-Exercise")
                        {

                            lessons.RemoveAt(index1 + 1);
                            index1 = lessons.IndexOf(command[1]);//za6toto ve4e sum premestil
                                                                 //ne6toto koeto se namira na index2+1 i ne6tata 
                                                                 //             sa se razmestili
                            lessons.Insert(index1 + 1, $"{command[1]}-Exercise");
                        }
                        else if (index2 + 1 >= 0 && index2 + 1 < lessons.Count && lessons[index2 + 1] == $"{command[2]}-Exercise")
                        {
                            lessons.RemoveAt(index2 + 1);
                            index2 = lessons.IndexOf(command[2]);//za6toto ve4e sum premestil
                                                                 //ne6toto koeto se namira na index2+1 i ne6tata sa se razmestili

                            lessons.Insert(index2 + 1, $"{command[2]}-Exercise");
                        }
                    }
                }
                else if (command[0] == "Exercise")
                {
                    int lessonIndex = lessons.IndexOf(command[1]);
                    if (lessons.Contains(command[1]) && !lessons.Contains($"{command[1]}-Exercise"))
                    {
                        lessons.Insert(lessonIndex + 1, $"{command[1]}-Exercise");
                    }
                    if (!lessons.Contains(command[1]))
                    {
                        lessons.Add(command[1]);
                        lessons.Add($"{command[1]}-Exercise");
                    }
                }
            }
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
