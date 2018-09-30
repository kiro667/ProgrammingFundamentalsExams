using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            var sections = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);//делим входа на части
            var regex1 = new Regex(@"([#$%*&])([A-Z]+)(\1)");//намираме валидните главни букви
            var firstGroup = sections[0];

            var matcher = regex1.Match(firstGroup);
            if (matcher.Success)//влиза само ако има ваидни главни букви
            {
                var allCapitals = matcher.Groups[2].Value;//правим масив от char
                var secondGroup = sections[1];
                var allWords = sections[2].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);//треатата част делим по space

                foreach (var character in allCapitals)
                {
                    int charAsInt = (int)character;
                    regex1 = new Regex($"{charAsInt}:(\\d\\d)");//iskam da mi 
                    //ma4ne charAsInt i nqkakvo dvucifreno 4islo
                    matcher = regex1.Match(secondGroup);
                    var length = int.Parse(matcher.Groups[1].Value) + 1;
                    //Groups[1] e (\\d\\d)
                    foreach (var word in allWords)
                    {
                        if (word.ElementAt(0) == character && word.Length == length)
                        {
                            Console.WriteLine(word);
                            //   break;
                        }
                    }
                }

            }
        }
    }
}
