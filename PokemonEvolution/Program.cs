using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonEvolution
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = "";
            string evolution = "";

            Dictionary<string, List<string>> pokemons = new Dictionary<string, List<string>>();
            //izbrirame Dictionary za6toto imame mnogo vidove pokemoni 6te trqbva da printirame za vseki edin ot tqh
            //posle List za6toto vseki pokemon moje da ima pove4e evolucii string za6toto tova za sega nqma da e 4islo
            //nqma da go pazq kato 4islo//1-to e imeto na 2-to sa eloluciite na pokemona Hybrid -> 100
            while (input[0] != "wubbalubbadubdub")
            {
                if (input.Length > 1)//imame 2 vuzmojni input 1-qt na4in e //Meowth -> Physical -> 50
                                     //tozi pokemon e evoilal po tozi na4in i e subral tolkova to4ki 2-qt na4in 
                                     //e da ni kajat
                                     //samo imeto na pokemona i togava trqbva da printirame statistika za nego//Pikachu
                {
                    name = input[0];
                    evolution = input[1] + " <-> " + input[2];

                    if (!pokemons.ContainsKey(name))
                    {
                        List<string> currentList = new List<string>() { evolution };
                        //za sega v nego ima samo edin 4len koito e evolution
                        //napravi mi edin list v koito vkarai 1-vi 4len evolution 
                        pokemons.Add(name, currentList);//i posle v Dictionary natup4i ime i sre6tu nego tozi list
                    }
                    else
                    {//ako ve4e se sudurja tozi pokemon nqmame nujda ot new list za6toto toi inicializiran gore
                        //zatova prosto mu dobavi tazi evoluciq v lista //toest akove4e go imame edin put tozi pokemon
                        // i sega go imame za 2-ri 3-ti i t.n
                        pokemons[name].Add(evolution);//tova e ot tip list zatova mu dobavqm direktno  evolution
                        //
                    }
                }
                else
                {//ako iska statistika vzimam si koe mi e imeto i mu kazvam//tova e slu4aq kogato imam samo ime
                    name = input[0];

                    if (pokemons.ContainsKey(name))//ako se sudurja tova ime izprintirai mi imeto 
                    {
                        Console.WriteLine($"# {name}");
                        //a sled tova v edin foreeach mi printirai vsqka evoluciq
                        foreach (var ev in pokemons[name])//za tozi pokemon printirame vsqka negova evoluciq
                        {
                            Console.WriteLine($"{ev}");//tova e List ot stringove
                        }
                    }
                }
                input = Console.ReadLine().Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            }
            foreach (var pair in pokemons)
            {
                Console.WriteLine($"# {pair.Key}");//pair.Key za6toto ve4e razglejdame cqloto Dictionary v koeto ima
                //mnogo pokemoni i  vuv vseki edin ot tqh ima List s mnogo evolucii//printirai mi pair.Key koeto e 
                //imeto
                foreach (var ev in pair.Value.OrderByDescending(x => int.Parse(x.Split(new char[] { '<', '-', '>', ' ' },
                    StringSplitOptions.RemoveEmptyEntries).Skip(1).First())))
                //sled tova za vsqka evoluciq v tozi pair toest v pair.Value mi printirai evoluciqta
                //sled kato go razdelq po znaci //kato go razdeli po znaci 6te izleze edin masiv ot dve ne6ta
                //Hybrid -> 100//pusni ednoto i vzemi 1-to //parse go i stava 4islo sled tova gi podrejdam po golemina
                //
                //.Skip(1) 6te mi propusne imeto//kogato radeli po split opciqta to 6te propusne tezi znaci i Physical 
                //6te e v na4aloto v kraq 6te bude power//Physical <-> 100//na nas ni trqbva oba4e power za6toto iskame 
                //da go podredim po 4islata propuskame edna i togava vzimame 1-ta//skip(1) propuska imeto na evolucioniq tip
                {
                    Console.WriteLine($"{ev}");
                }
            }
        }
    }
}
