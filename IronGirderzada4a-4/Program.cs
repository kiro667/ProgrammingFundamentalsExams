//??za6to imame break; v koda  dolu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MobaChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            //6te pazim plyer-rite s tehnite position-ni i s tehnite skill-love   
            //   za klu4 imeto 6te bude string za Value 6te imame o6te edno Dictionary koeto za klu4
            // 6te sudurja string tui kato position 6te ni bude nqkakuv tekst nqma da sa 4isla i int za 
            //skill-la
            //1-to e Key 2-to e Value
            //   Dictionary<string, int> kali = new Dictionary<string,int>();
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();                                     //
            while (true)
            {

                List<string> inputType = new List<string>();
                string input = Console.ReadLine();
                if (input == "Season end")
                {
                    break;
                }

                if (input.Contains(" -> "))
                {
                    inputType = input.Split(" -> ").ToList();
                }
                else if (input.Contains("vs"))
                {
                    inputType = input.Split(" vs ").ToList();
                }

                if (inputType.Count == 3)
                {
                    string playerName = inputType[0];
                    string position = inputType[1];
                    int skill = int.Parse(inputType[2]);

                    if (!players.ContainsKey(playerName))
                    {//ako v players nqma takova ime
                        players.Add(playerName, new Dictionary<string, int>());
                        //new Dictionary za6toto tezi ne6ta 6te se pulnqt s drugi stoinosti
                    }

                    if (!players[playerName].ContainsKey(position))//
                    {//tuk trqbva da proverim dali na6iq position su6to se sudurja //
                        //i ako ne se sudurja togava da go dobavim
                        players[playerName].Add(position, skill);
                        //ako polu4im ednakuv player no razli4en skill nie trqbva da prezapi6em 
                        //stoinostta v skill no samo kogato tq e po-golqma ot dadenata ni
                        //v tozi if proverqvam dali se sudurja 
                    }
                    else
                    {//v else e kogato imame ve4e takuv position v na6ata struktura
                        if (skill > players[playerName][position])
                        {//skill-la koito ni idva ot 
                         //konzolata trqbva da go sravnim s ne6to
                         //  skill-la trqbva da ni e po-golqm ot tozi koito ve4e e zapisan
                            players[playerName][position] = skill;

                        }
                    }
                }
                else if (inputType.Count == 2)
                {
                    string firstPlayer = inputType[0];
                    string secondPlayer = inputType[1];
                    if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPlayer))
                    {
                        //qvno pri re4nicite se vru6ta taka .ToArray()
                        string[] firstPlayerPositions = players[firstPlayer].Keys.ToArray();
                        //  Console.WriteLine(string.Join(" ", firstPlayerPositions));
                        // primerno imam Pesho -> Adc -> 400 6te izprintira Adc 
                        //edin vid klu4ova na Pe6to e Adc
                        // e.g
                        //Pesho->Adc-> 400
                        //Bush->Tank-> 150
                        //Faker->Mid-> 200
                        // Klu4ovete na Pesho,Bush i Faker sa Adc,Tank i Mid
                        //tova na dolniq red
                        // 6te izprintira tova 
                        //   vtoroto

                        foreach (var pos2 in players[secondPlayer].Keys)
                        {
                            if (firstPlayerPositions.Contains(pos2))
                            {
                                int totalSkillsFP = players[firstPlayer].Values.Sum();
                                int totalSkillsSP = players[secondPlayer].Values.Sum();
                                //tova e s posledniq output na zada4ata
                                //  Console.WriteLine(totalSkillsFP);//700
                                //  Console.WriteLine(totalSkillsSP);//500


                                if (totalSkillsFP > totalSkillsSP)
                                {
                                    players.Remove(secondPlayer);
                                    //tova e primeren output Faker pe4eli i drugite se mahat
                                    //  Faker: 700 skill
                                    //  - Support <::> 250
                                    //  - Tank <::> 250
                                    //  - Mid <::> 200
                                    //  Pesho: 400 skill
                                    //  - Adc <::> 400



                                    //kogato iztriem nqkoi igra4 ot kolekciqta ni trqbva da si breiknem cikula za da ne se polu4ava 
                                    //taka 4e 2 puti da vleznem v taq proverka da si suzdadem nqkakvi ne6ta i to 6te ni grumne o6te na 
                                    //vtoriq red ot uslovieto na gorniq if za6toto primerno iztrili sme secondPlayer i sled tova kato 
                                    //trugnem da inicializirame ne6to koeto go nqma i programata ni 6te izgurmi// za da moje prosto 
                                    //kogato namerim edno suvpadenie nie vlizame v gorniq if suzdaveme si gi sumite im proverqvame gi iztri-
                                    //vame si koito ni trqbva i break-vame i pove4e ne iskame da minavame prez toq cikul t.e nie iskame 
                                    //nanovo da suzdavame izpulnili sme uslovieto iztrili sme si 4oveka i sme priklu4ili
                                    break;
                                }
                                else if (totalSkillsFP < totalSkillsSP)
                                {
                                    players.Remove(firstPlayer);
                                    break;
                                }
                            }
                        }

                    }
                }

            }
            foreach (var p in players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(n => n.Key))//1-to 6te value e
                                                                                                      //re4nik 2-to e stoinostta na re4nika
            {//x-sa 6te mu vzemem Value-to koeto e re4nik i na tozi re4nik trqbva da mu vzemem Value-tata
             //i na tezi Value-ta da im kajem .Sum
                Console.WriteLine($"{p.Key}: {p.Value.Values.Sum()} skill");
                foreach (var pos in p.Value.OrderByDescending(s => s.Value).ThenBy(c => c.Key))
                {
                    Console.WriteLine($"- {pos.Key} <::> {pos.Value}");
                }
            }

        }
    }
}
