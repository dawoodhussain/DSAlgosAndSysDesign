using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2020Challenge
{
//Given an array of size n, find the majority element.The majority element is the element that appears more than ⌊ n/2 ⌋ times.
//You may assume that the array is non-empty and the majority element always exist in the array.
//Example 1:
//Input: [3,2,3]
//Output: 3

//Example 2:
//Input: [2,2,1,1,1,2,2]
//Output: 2
    public class MajorityElementProblem
    {
        // O(n) time | O(1) space - Boyer-Moore voting Algorithm
        public int MajorityElement(int[] nums)
        {
            int count = 0, candidate = 0;
            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                count += (candidate == num) ? 1 : -1;
            }
            return candidate;
        }

        // O(nlogn) time | O(1) space
        public int MajorityElementUsingSort(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }

        //O(n) time | O(n) space
        public int MajorityElementUsingHashMap(int[] nums)
        {
            Dictionary<int, int> vLookUp = new Dictionary<int, int>();
            int currentCount = 1, answer = nums[0];
            foreach (int num in nums)
            {
                if (vLookUp.ContainsKey(num))
                {
                    vLookUp[num] = vLookUp[num] + 1;
                    if (vLookUp[num] > currentCount)
                    {
                        currentCount = vLookUp[num];
                        answer = num;
                    }
                }
                else
                {
                    vLookUp.Add(num, 1);
                }
            }
            return answer;
        }
    }
}
