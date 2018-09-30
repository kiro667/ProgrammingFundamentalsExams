using System;
using System.Collections.Generic;
using System.Linq;

namespace _2examprep4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();
            Dictionary<string, int> colors = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Once upon a time")
                {
                    break;
                }
                string[] tokens = line
                    .Split(new[] { " <:> " },
                        StringSplitOptions.RemoveEmptyEntries);
                string dwarfName = tokens[0];
                string dwarfHatColor = tokens[1];
                int dwarfPhysics = int.Parse(tokens[2]);
                if (!colors.ContainsKey(dwarfHatColor))
                {
                    colors.Add(dwarfHatColor, 1);// ako nqma takava 6apka
                    // q dobavqne i kazvame 4e q ima ve4e sled kato sme q dobavili edin put
                }
                else//a puk ako q ima prebroqvame kolko puti q ima
                {
                    colors[dwarfHatColor]++;

                }
                string currentDwarfId = $"{dwarfName} <:> {dwarfHatColor}";

                if (!dwarfs.ContainsKey(currentDwarfId))
                {
                    dwarfs.Add(currentDwarfId, dwarfPhysics);
                }
                else
                {
                    int oldValue = dwarfs[currentDwarfId];
                    if (dwarfPhysics > oldValue)
                    {
                        dwarfs[currentDwarfId] = dwarfPhysics;
                    }
                }
            }





            // start ???
            Dictionary<string, int> sortedDwarfs = dwarfs
                .OrderByDescending(d => d.Value).ThenByDescending(d => colors[d.Key.Split(new[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries)[1]]) // d.key взима ключа от джуджета (име + цвят) 
                                                                                                                                                         // този ключ го подаваме на метода getDwardfColorOcurences, който ни връща цвета
                                                                                                                                                         // colors[ от този цвят ] ще ни върне колко често се среща този цвят, което е нещото, по което се сортират джуджетата



                        .ToDictionary(x => x.Key, x => x.Value);//nakraq taka kazvame 4e gi podrejdame
                                                                //d.Key.Split(new[] { " <:> " },StringSplitOptions.RemoveEmptyEntries)[1]                                   //1-vo po klu4 posle po Value
            foreach (var dwarf in sortedDwarfs)
            {
                string dwarfId = dwarf.Key;//ime na djudje i cveta mu
                string[] dwarfIdTokens = dwarfId.Split(new[] { " <:> " },
                    StringSplitOptions.RemoveEmptyEntries);
                string dwarfName = dwarfIdTokens[0];
                string dwarfHatColor = dwarfIdTokens[1];

                int dwarfPhysics = dwarf.Value;

                Console.WriteLine($"({dwarfHatColor}) {dwarfName} <-> {dwarfPhysics}");
            }
        }
        //end if ???
        private static string getDwardfColorOcurences(string drardNameAndColor)
        {
            string[] array = drardNameAndColor.Split(new[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries);
            string color = array[1];
            return color;
        }
    }
}