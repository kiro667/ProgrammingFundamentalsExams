using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();
            //1-to e DateSet 2-to e dataKey i 3-toto e dataSize

            while (input != "thetinggoesskrra")
            {

                string[] inputSplit = input.Split(new char[] { ' ', '-', '>', '|' },
                 StringSplitOptions.RemoveEmptyEntries);



                if (inputSplit.Length > 1)
                {//
                    string dataKey = inputSplit[0];
                    long dataSize = long.Parse(inputSplit[1]);
                    string dataSet = inputSplit[2];

                    if (!data.ContainsKey(dataSet))
                    {
                        data.Add(dataSet, new Dictionary<string, long>());//trqbva da si inicializiram vutre6noto 
                        //Dictionary ne go li inicializiram 6te stoi nula

                    }

                    data[dataSet][dataKey] = dataSize;//ako se sudurjat v re4nika tezi koito se sudurjat ve4e 6te sum gi dobavil po-gore
                                                      //data[vun6en klu4][vutre6en klu4] = dataSize//za6toto stoinostta se promenq az ve4e sum si zapazil dateSet i dataKey no  stoinostta se prome nq
                                                      //e.g
                                                      //Students -> 2000 | Users
                                                      //Students -> 24233 | Users


                }



                input = Console.ReadLine();
            }

            if (data.Count > 1)
            {// ako imam izob6to nqkakva informaciq v moeto Dictionary ako e >1 zna4i imam pone edno entry tr
                // da napravq vsi4kite manipulacii vutre
                var dataSetWithMaxSize = data.OrderByDescending(x => x.Value.Sum(d => d.Value)).First();
                //purvo 6te gi podredi po golemina nai-golemite 6te gi izkara nai-otgore posle 6te gi sumira i 6te vzeme purviqt 
                //vhod(tezi koito sa nai-golemi)


                Console.WriteLine($"Data Set: {dataSetWithMaxSize.Key}, Total Size: {dataSetWithMaxSize.Value.Sum(d => d.Value)}");

                //.Value kato kaja direktno zadraskvam vun6noto Dictionary



                foreach (var inner in dataSetWithMaxSize.Value)
                {
                    Console.WriteLine($"$.{inner.Key}");
                }
            }








        }
    }
}
