using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string didiPattern = @"[^A-Za-z-]+";
            string bojoPattern = @"[A-Za-z]+-[A-Za-z]+";
            int round = 1;//poneje se reduvat az ne moga da mu kaja tursi mi samo po didi ili samo po bojo tu ediniq  tu 
            //drugiq zatova s 4etno i ne4etno kazvam mu edin round e.g po4vam ot 1-vi krug 

            while (true)
            {

                if (round % 2 == 1)//ako sme v ne4eten e Didi
                {
                    if (!Regex.IsMatch(input, didiPattern))//ako nqmame takuv match izlizame ot programata
                    {
                        return;//za da mojem da minem kum Bojo zatova ne e break a return tuk e vajno da e return a ne 
                        //break za6toto ako e break 6te se zavurti pak i 6te stava edno i su6to

                    }
                    else
                    {
                        Match current = Regex.Match(input, didiPattern);//tq moje da ima pove4e ot edin ma4ove no tova 
                        //6te vzeme 1-qt zatova ne e MatchCollection za6toto MatchCollection 6te gi subere vsi4kite 
                        //a nie iskame da vidim kakvo 6te napravi Bojo za6toto Bojo moje da prekusne while cikula i 
                        //i toi 
                        //sled kato sme vzeli edin Match po-dobre da iztriem vsi4ko predi tova za da zapo4ne Bojo da 
                        //si subira na 4isto  zatova dolniq red//ako ima takuv Match vzimame 1-qt Match vuzmojen
                        //sled tova go printirame i sled tova samiqt input go namalqme iztrivame tova koeto didi
                        //e printirala
                        input = input.Substring(current.Index + current.Length);//az iskam da vzema momenta sled 
                        //kato Didi ve4e si e vzela neiniq zatova 6te se opitam da si vzema indeksa na Didi 
                        //tova v skobite pravi tozi red vidq 4e current.Index e 0 za6toto zapo4va ot samoto na4alo
                        //sled tova dobavi  Length(3) e sega 6te ostavi vsi4ko ostanalo t.e 3-ti simvol 6te stane 0 i taka
                        //nie pridavame na na6iqt input nova stoinost i tazi stoinost e vzemi ot koqto zapo4va na poziciq
                        // current.Index t.e nameri mi ot kude zapo4va realno current.Index e 0-va poziciq za6toto 
                        //tova e mqstoto kudeto zapo4va current a Length mu e 3 0+3 e 3 t.e  toi znae 4e novata stoinost 
                        //zapo4va ot poziciq nomer 3 na koqto v slu4aq se namira a
                        Console.WriteLine(current.ToString());//i nakraq trqbva da printirame i mu kazvam .ToString()
                        //za6toto current vupreki 4e e tekst ne e string toi e match koeto e otdelen tip
                    }
                }
                else
                {
                    if (!Regex.IsMatch(input, bojoPattern))
                    {
                        return;
                    }
                    else
                    {
                        Match current = Regex.Match(input, bojoPattern);
                        input = input.Substring(current.Index + current.Length);
                        Console.WriteLine(current.ToString());
                    }
                }

                round++;//kato minem i dvamata trqbva da uveli4im round za6toto  gledame samo Didi
            }

        }
    }
}
