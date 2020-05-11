using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2020Challenge
{
    public class FirstBadVersionProblem
    {
        //Given n = 5, and version = 4 is the first bad version.
        //    call isBadVersion(3) -> false
        //    call isBadVersion(5) -> true
        //    call isBadVersion(4) -> true
        //    Then 4 is the first bad version.

        //O(logn) time | O(1) space
        public int FirstBadVersion(int n)
        {
            int left = 1, right = n, mid = 0;
            while (right - left > 0)
            {
                mid = left + (right - left) / 2;
                bool isBad = IsBadVersion(mid);
                if (isBad)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        private bool IsBadVersion(int mid) // This will be provided by leetcode internally
        {
            throw new NotImplementedException();
        }

        //2nd approach using Linear scan - O(n) time | O(1) space
    }
}
