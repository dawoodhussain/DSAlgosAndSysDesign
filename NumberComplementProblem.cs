using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2020Challenge
{
    //Given a positive integer, output its complement number. The complement strategy is to flip the bits of its binary representation.
    //Input: 5
    //Output: 2
    //Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.

     //Input: 1
     //Output: 0
     //Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
    public class NumberComplementProblem
    {
        //trick: Find the number that has the same number of bits as the given number and all the bits are set. XOR it with the given number to get the result.
        public int FindComplement(int num)
        {
            double i = 0;
            int j = 0;
            while (i < num)
            {
                i += Math.Pow((int)2, (int)j);
                j++;
            }
            return (int)i ^ num; //you can return i-num as well. it would deliver the same result
        }

        public int FindComplement3(int num)
        {
            int temp = num;
            int nn = 1;
            while (temp > 1)
            {
                nn = nn << 1;
                nn = nn + 1;
                temp = temp / 2;
            }
            return nn ^ num;
        }
    }
}
