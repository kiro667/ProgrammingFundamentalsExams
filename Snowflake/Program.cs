using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp31// .*-ta hva6ta 0 ili pove4e a + sa edin ili pove4e ma4a .+
{
    class Program//(.*) (\1)   //ma4vai vsi4ko dokato ne nameri6 analogi4no na 1-ta grupa (\1) tova edin vid kazva vzemi mi su6tata grupa kato 1-ta
    {//.*  // zvezdata hva6ta 0 ili pove4e sled tova +  hva6ta edin ili pove4e ma4a
        static void Main(string[] args)
        {

            //         string encodedText = Console.ReadLine();
            //         //string-ga go pravq na masiv ot character - ri  i sled toq masiv ot character mi se zapazva 0-lev element v placeholder
            //         //analogi4no e na new char i dvata placeholder-ra
            //         string[] placeholders = Console.ReadLine().Split("{}".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            //
            //         string pattern = @"([A-Za-z]+)(.+)(\1)";
            //
            //         var matches = Regex.Matches(encodedText,pattern);


            string encodedText = Console.ReadLine();
            string[] placeholders = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);


            //  string pattern = @"([A-Za-z]+)(.+)(\1)";//(tova zna4i 4e poslednoto iskam da e su6toto kato 1-to)
            //()-te pokazvat kolko grupi sa

            Regex pattern = new Regex(@"([A-Za-z]+)([\x00-\x7F]+)(\1)");

            MatchCollection matches = pattern.Matches(encodedText);

            int count = 0;

            foreach (Match match in matches)
            {
                string decodedMessage = match.Groups[1] + placeholders[count++] + match.Groups[3];//1-vo 6te vzeme 
                //0-viq element posle 1-qt i taka dokato imam elementi 
                //{this}{exam}{problem}{is}{boring}   za 0-lev 6te vzeme this za 1-vi exam i t.n



                encodedText = encodedText.Replace(match.Value, decodedMessage);// tova na mqstoto na match.Value slagam decodeMessage

            }
            Console.WriteLine(encodedText);



        }
    }
}
