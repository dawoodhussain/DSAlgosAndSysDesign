using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2020Challenge
{
//Given a positive integer num, write a function which returns True if num is a perfect square else False.
//Note: Do not use any built-in library function such as sqrt.

//Example 1:
//Input: 16
//Output: true

//Example 2:
//Input: 14
//Output: false
    public class ValidPerfectSquare
    {
        //Optimized approach: using BinarySearch O(logN)time | O(1) space
        public bool IsPerfectSquare(int num)
        {
            long left = 0, right = num;
            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                //int mid = (left+right)/2; to accept values beyond integer limit
                if (mid * mid == num)
                {
                    return true;
                }
                else if (mid * mid < num)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return false;
        }

        /*
        1:  1
        4:  1 + 3
        9:  1 + 3 + 5
        16: 1 + 3 + 5 + 7
        25: 1 + 3 + 5 + 7 + 9   

        Time: O(sqrt(num))
              num = 1 + 2 + 3 + ... + n = n*(n+1)/2 => n = O(sqrt(num))
        Space: O(1)
        */
        public bool IsPerfectSquareUsingMath(int num)
        {
            int i = 1;
            while (num > 0)
            {
                num = num - i;
                i = i + 2;
            }

            return num == 0 ? true : false;
        }

        //trick: if you divide the number (n) by its squaring digit (x), quotient should be equal to (x) and remainder should be equal to 0.
        public bool IsPerfectSquareLinearSearch(int num)
        {
            //square of a number x should not cross squared number (n)
            for (long i = 1; i * i <= num; i++)
            {
                if (num % i == 0 && num / i == i)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
