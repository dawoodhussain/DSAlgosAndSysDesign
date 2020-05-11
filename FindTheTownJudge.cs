using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2020Challenge
{
//In a town, there are N people labelled from 1 to N.There is a rumor that one of these people is secretly the town judge.

//If the town judge exists, then:
//The town judge trusts nobody.
//Everybody (except for the town judge) trusts the town judge.
//There is exactly one person that satisfies properties 1 and 2.

//You are given trust, an array of pairs trust[i] = [a, b] representing that the person labelled a trusts the person labelled b.
//If the town judge exists and can be identified, return the label of the town judge.  Otherwise, return -1.

//Example 1:
//Input: N = 2, trust = [[1, 2]]
//Output: 2

//Example 2:
//Input: N = 3, trust = [[1,3],[2,3]]
//Output: 3

//Example 3:
//Input: N = 3, trust = [[1,3],[2,3],[3,1]]
//Output: -1

//Example 4:
//Input: N = 3, trust = [[1,2],[2,3]]
//Output: -1

//Example 5:
//Input: N = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]]
//Output: 3
 
//Note:
//1 <= N <= 1000
//trust.length <= 10000
//trust[i] are all different
//trust[i][0] != trust[i][1]
//1 <= trust[i][0], trust[i][1] <= N
    public class FindTheTownJudge
    {
        //optimized approach. Let's try to do with just 1 additional array or dict
        public int FindJudge(int N, int[][] trust)
        {
            if (N == 1) return 1;
            int[] possibleJudge = new int[N + 1];
            foreach (int[] t in trust) //O(n)
            {
                possibleJudge[t[1]]++;
                possibleJudge[t[0]]--;
            }
            for (int i = 0; i < N + 1; i++)
            {
                //everybody trusts Judge except him. so answer is total no: of people - 1 
                if (possibleJudge[i] == N - 1) return i;
            }
            return -1;
        }

        // O(N+m) time | O(N) space
        public int FindJudge1(int N, int[][] trust)
        {
            if (N == 1) return 1;
            if (N == 2 && trust.GetLength(0) == 1) return trust[0][1];

            int[] truster = new int[N + 1];
            int[] trustee = new int[N + 1];

            foreach (int[] t in trust) //O(n)
            {
                trustee[t[1]]++;
                truster[t[0]]++;
            }
            for (int i = 0; i < N + 1; i++)
            {
                // everybody trusts Judge except him. so answer is total no: of people - 1 
                if (trustee[i] == N - 1 && truster[i] == 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
