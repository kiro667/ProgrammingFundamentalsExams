using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace ForceBook
{
    class Program//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        static void Main(string[] args)//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // edin forceSide moje da ima mnogo user-i//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //trqbva za vsqko edno key vuv re4nika dali sudurja tova Value i ako su6testvuva trqbva da go mahna 
            //ot tozi List i da go dobavq vuv Value-to na klu4a na koito mi e noviq sait 
            // 1-to e Dark ili Light 2-to e imeto

            //        Ivan Ivanov joins the Lighter side!
            //        DCay joins the Lighter side!
            //        Side: Lighter, Members: 3
            //        !DCay
            //        !Ivan Ivanov
            //            !Royal
            //edin forceSide moje da ima mnogo user-ri
            //           Primerno tuk imam Side:Lighter toi ima 3 - members zna4i side 6te ni e klu4 a Value-to ni 6te e List za6toto vseki edin side moje da ima mnogo users


            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Lumpawaroo")
                {
                    break;
                }

                if (line.Contains("|"))
                {
                    string[] tokens = line.Split(" | ");
                    string side = tokens[0];
                    string user = tokens[1];

                    if (!sides.ContainsKey(side))
                    {
                        sides.Add(side, new List<string>());//ako go nqma si godavqmw s prazen List i posle kum 
                                                            //toq List 
                                                            //trqbva da dobavq user-a ako go nqma
                    }

                    if (!sides.Values.Any(x => x.Contains(user)))
                    {
                        sides[side].Add(user);
                    }


                }

                else
                {
                    string[] tokens = line.Split(" -> ");
                    string side = tokens[1];
                    string user = tokens[0];

                    if (sides.Values.Any(x => x.Contains(user)))//za6toto edin side moje da ima
                                                                //mnogo user-ri
                    {

                        sides.Values.First(x => x.Contains(user)).Remove(user);
                        //6te vzeme 1-ta stoinost koqto sudurja tozi user i taka s vsqko zavurtane na while
                        // 6te gi vzeme vsi4kite

                        //po tozi na4in 6te si izvadq 1-qt
                        //koito sudurja tozi user 
                        //sides mi e Dictionary .Values mi vru6ta vsi4ki Value-ta koito sa List-ove izvadi mi 1-qt list
                        // kudeto toq List sudurja toq user i go mahni// ako go imam toq user nqkude v List-a 
                        //go maham ot List-a i go dobavqm v re4nika  // mahame go samo ot 1-qt List za6toto nie sme 
                        //sigurni 4e ako go ima 6te go ima samo vednuj za6toto nie se podsigurqvame vseki put pri dobavqne pri triene i t.n

                        if (!sides.ContainsKey(side))
                        {//ako go nqma toq side go dobavqme i posle mu dobavqme//
                            //toq user
                            sides.Add(side, new List<string>());
                        }

                        if (!sides[side].Contains(user))
                        {
                            sides[side].Add(user);//tova 6te raboti samo ako imam stranata//!!!!
                        }

                        Console.WriteLine($"{user} joins the {side} side!");

                    }

                    else
                    {

                        if (!sides.ContainsKey(side))
                        {
                            sides.Add(side, new List<string>());
                        }
                        if (!sides[side].Contains(user))
                        {
                            sides[side].Add(user);//tova 6te raboti samo ako imam stranata//!!!!
                        }
                        Console.WriteLine($"{user} joins the {side} side!");
                    }

                }


            }

            foreach (var kvp in sides.OrderByDescending(x => x.Value.Count)
                .ThenBy(y => y.Key))
            {

                if (kvp.Value.Count != 0)//ako broikata na user-rite e !=0
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (string user in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }

                }

            }

        }
    }
}
