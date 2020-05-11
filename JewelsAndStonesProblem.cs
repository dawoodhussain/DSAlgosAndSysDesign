using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2020Challenge
{
//You're given strings J representing the types of stones that are jewels, and S representing the stones you have.  Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.
//The letters in J are guaranteed distinct, and all characters in J and S are letters.Letters are case sensitive, so "a" is considered a different type of stone from "A".
//Input: J = "aA", S = "aAAbbbb"
//Output: 3

//Input: J = "z", S = "ZZ"
//Output: 0
    public class JewelsAndStonesProblem
    {
        // O(J+S) time | O(J) space
        public int NumJewelsInStones(string J, string S)
        {
            HashSet<char> hset = new HashSet<char>();
            foreach (char jewel in J)
            {
                if (!hset.Contains(jewel))
                {
                    hset.Add(jewel);
                }
            }
            int output = 0;
            foreach (char stone in S)
            {
                if (hset.Contains(stone))
                {
                    output++;
                }
            }
            return output;
        }

        //O(n*m) time | O(1) space
        public int NumJewelsInStonesBruteForce(string J, string S)
        {
            int output = 0;
            foreach (char Jewel in J)
            {
                foreach (char stone in S)
                {
                    if (Jewel - stone == 0)
                    {
                        output++;
                    }
                }
            }
            return output;
        }
    }
}
