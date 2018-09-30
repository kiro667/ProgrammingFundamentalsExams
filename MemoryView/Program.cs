using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace MemoryView
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
                e
    }
}
