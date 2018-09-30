using System;
using System.Numerics;//za da mi raboti BigInteger
using System.Linq;
using System.Collections.Generic;
using System.Text;//zaradi String Builder

namespace PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {//na ediniq red ni se dava List ili masiv(az izbiram kakvo da polzvam) trqbva da sledim nqkakva suma i
            //polu4avame komandi do nqkakuv moment

            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int sum = 0;
            int index = 0;
            int current = 0;
            while (nums.Count > 0)
            {//dokato ne se izprazni lista pravi nqkakvi ne6ta kato priklu4i6 
             //s tova mi izprintirai sum
                index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    current = nums[0];
                    nums[0] = nums[nums.Count - 1];//tova v skobite e nomera posledniq element
                }
                else if (index > nums.Count - 1)
                {
                    current = nums[nums.Count - 1];
                    nums[nums.Count - 1] = nums[0];
                }
                else
                {
                    current = nums[index];
                    nums.RemoveAt(index);
                }
                sum += current;
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] <= current)
                    {
                        nums[i] += current;
                    }
                    else
                    {
                        nums[i] -= current;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
