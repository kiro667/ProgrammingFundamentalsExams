using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._AnonymousThreat
{
    class AnonymousThreat
    {
        static void Main(string[] args)
        {

            int[] seq = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //trqbva da si zapazim snejnite 4oveci koito sa zagubili tazi bitka
            while (seq.Length > 1)
            {//trqbva da pravim na6te bitki dokato imame pove4e ot edin snejen 4okvek
                List<int> losers = new List<int>();//za6toto na vsqko novo obhojdane trqbva da zapo4vame sus 
                //snejen 4ovek //List za6toto trqbva da si zapazim po nqkakuv na4in snejnite 4oveci koito sa 
                //zagubili tazi bitka


                for (int attacker = 0; attacker < seq.Length; attacker++)
                {
                    int target = seq[attacker] % seq.Length;

                    int diff = Math.Abs(attacker - target);

                    //za6tot0 primerno kogato ostanat 4 i 3 kogato 4-ta zagubi nie trqbva da priklu4im sledovatelno
                    // nqma nujda da produljavame napred za6toto tozi snejen 4ovek trqbva da ocelee kogato e edin
                    //toi trqbva da ocelee
                    if (seq.Length - losers.Count == 1)
                    {
                        //za6tot0 primerno kogato ostanat 4 i 3 kogato 4-ta zagubi nie trqbva da priklu4im 
                        //sledovatelno nqma nujda da produljavame napred za6toto tozi snejen 4ovek trqbva 
                        // da ocelee kogato e edin toi trqbva da ocelee

                        break;
                    }

                    if (losers.Contains(attacker))//Ako imame nqkoi element koito gubi toi ne moje da atakuva
                        // i ako tozi element koito atakuva v momenta e ve4e zagubil trqbva da podminem tazi bitka i
                        //da produljim sus sledva6tata
                        continue;

                    //kogato imame samoubiistvo
                    //ako mu kajem dali e 4etno purvo kogato imame nqkakuv snejen 4ovek koito 
                    //6te se samoubiva tova 6te e problem sledovatelno posledniq else idva purvi
                    //6te izpolzvam attacker == target
                    if (attacker == target)
                    {
                        Console.WriteLine($"{attacker} performed harakiri");
                        losers.Add(attacker);//poneje snejniq 4ovek se razru6ava
                        seq[attacker] = -1;//tuk durjim snejnite 4oveci koito sa se samoubili

                    }
                    else if (diff % 2 == 0)
                    {
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                        //kogato attacker spe4eli zagubiliq e target
                        losers.Add(target);//poneje attacker pe4eli target go dobavqm kum zagubilite
                        seq[target] = -1;//tuk durjim snejnite 4oveci koito sa zagubili

                    }
                    else
                    {

                        Console.WriteLine($"{attacker} x {target} -> {target} wins");//kogato target spe4eli
                        //na6iqt zagubil snejen 4ovek e attacker
                        losers.Add(attacker);//poneje target pe4eli attacker go dobavqm kum zagubilite
                        seq[attacker] = -1;//tuk durjim snejnite 4oveci koito sa zagubili 

                    }
                    losers = losers.Distinct().ToList();//za6toto snejniq 4ovek ne moje da zagubi 2 puti ili da se 
                    //samoubiee 2 puti//tova maha povtoreniqta
                }


                seq = seq.Where(n => n != -1).ToArray();//6te mahne zagubilite i samoubilite se snejni 4oveci
                //i kato mu kaja .TOArray() tova mi e novata poredica
            }

        }
    }
}
