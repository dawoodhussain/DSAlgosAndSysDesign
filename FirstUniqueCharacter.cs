using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2020Challenge
{
//Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.
//Examples:
//s = "leetcode"
//return 0.

//s = "loveleetcode",
//return 2.
//Note: You may assume the string contain only lowercase letters.
    public class FirstUniqueCharacter
    {
        // O(n) time | O(1) space
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>(); //O(1) just 26 characters
            foreach (char c in s) // O(n)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] = dict[c] + 1;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            // find the index. O(n)
            for (int i = 0; i < s.Length; i++)
            {
                if (dict[s[i]] == 1)
                    return i;
            }
            return -1;
        }
    }
}
