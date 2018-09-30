using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {

                string[] data = input.Split();

                string command = data[0];

                if (command == "merge")
                {

                    int startIndex = int.Parse(data[1]);
                    int endIndex = int.Parse(data[2]);

                    startIndex = validateIndex(startIndex, elements.Count);//kazva mi da podam index i nqkakva duljina
                    //moqt index e startIndex a puk duljinata e size na moq List
                    endIndex = validateIndex(endIndex, elements.Count);

                    string concatElements = "";

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatElements += elements[i];
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        elements.RemoveAt(startIndex);//maham 1-vi element za6toto primerno imam tri indeksa kato
                                                      //merge nuleviq i purviq 6te stanat dva indeksa s vsqko
                                                      //izminalo zavurtane na while
                                                      //dumate se namalqva

                    }

                    elements.Insert(startIndex, concatElements);//na start index 6te sloja slepenite elementi()

                }

                else if (command == "divide")
                {
                    int index = int.Parse(data[1]);
                    int partitionsCount = int.Parse(data[2]);

                    List<string> partitions = splitedEqually(elements[index], partitionsCount);//1-to e da go divide
                                                                                               // elementa na koito e indeksa 2-to e na kolko subbstring da go razdeli e.g abcd  a b cd
                                                                                               //kato purvi parametur podavam moqta duma kato 2-ri na kolko 4asti 6te go razdeli//sled kato si 
                                                                                               //napravq dolniqt metod tuk ve4e sa mi razcepenite 4asti


                    elements.RemoveAt(index);
                    elements.InsertRange(index, partitions);

                }


                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", elements));
        }

        private static List<string> splitedEqually(string word, int partitionsCount)//
        {// tova mi e metoda koito 6te mi razcepi dumata na 4asti i 6te q napulni v edin List i sled tova 6te si 
            //vurna Lista
            List<string> result = new List<string>();

            int part = word.Length / partitionsCount;//word e elements[index] ot gorniq metod partitionsCount e
            // partitionsCount ot gorniq metod


            while (word.Length >= part)
            {
                //Substring raboti kato se zadava startov index i duljina//e.g startov index e 0 duljinata 
                //e 2 zaradi tova zatova vzimam 1-te dva elementa a i b
                result.Add(word.Substring(0, part));
                //reja 1-te 2 charackter i si gi dobavqm v moq List kazvam 
                //izreji mi substring ot 0 do 2 i vzimam 1-vo a i b 
                word = word.Substring(part);//kazvam substring ot index[2] do kraq na dumata kato kaje6 Substring ot
                                            //nqkakuv index i to reje ot index vsi4ko natatuk//za6toto iskam 
                                            //ve4e da mi mahne tezi 
                                            //elementi koito ve4e sum gi razcepil//tova 6te mahne tazi duma koqto mve4e sum q razdelil na substring
            }



            if (result.Count == partitionsCount)
            {
                return result;
            }
            else
            {
                string conCatLastTwoElements = result[result.Count - 2] + result[result.Count - 1];
                result.RemoveRange(result.Count - 2, 2);//1-to e ot kude da po4ne da reje 2-to kolko da izreje
                result.Add(conCatLastTwoElements);
                return result;
            }

        }

        private static int validateIndex(int index, int length)//1-to e indeksa 2-to duljinata na moq masiv
        {

            if (index < 0)//tova e startIndex
            {
                index = 0;
            }

            if (index > length - 1)//tova e endIndex
            {
                index = length - 1;
            }
            return index;
        }

    }
}
