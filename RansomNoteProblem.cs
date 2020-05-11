using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2020Challenge
{
//Given an arbitrary ransom note string and another string containing letters from all the magazines, write a function that will return true if the ransom note can be constructed from the magazines ; otherwise, it will return false.
//Each letter in the magazine string can only be used once in your ransom note.

//Note:
//You may assume that both strings contain only lowercase letters.
//canConstruct("a", "b") -> false
//canConstruct("aa", "ab") -> false
//canConstruct("aa", "aab") -> true
    public class RansomNoteProblem
    {
        //O(M) time | O(1) space
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length) return false;

            int[] ransomArray = new int[26];
            foreach (char c in magazine)
            {
                ransomArray[c - 'a']++;
            }
            foreach (char c in ransomNote)
            {
                if (ransomArray[c - 'a'] > 0)
                {
                    ransomArray[c - 'a']--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        //O(r+m) time | O(1) space
        public bool CanConstructUsingHashMap(string ransomNote, string magazine)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>(); // O(r) space
            foreach (char c in ransomNote) //O(r) time
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
            foreach (char c in magazine) //O(m) time
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] = dict[c] - 1;
                }
            }
            foreach (KeyValuePair<char, int> entry in dict) //O(r) time
            {
                if (entry.Value > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
