using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2020Challenge
{
//You are given an array coordinates, coordinates[i] = [x, y], where[x, y] represents the coordinate of a point.Check if these points make a straight line in the XY plane.

//Example 1:
//Input: coordinates = [[1, 2], [2,3], [3,4], [4,5], [5,6], [6,7]]
//Output: true

//Example 2:
//Input: coordinates = [[1,1],[2,2],[3,4],[4,5],[5,6],[7,7]]
//Output: false
 
//Constraints:
//2 <= coordinates.length <= 1000
//coordinates[i].length == 2
//-10^4 <= coordinates[i][0], coordinates[i][1] <= 10^4
//coordinates contains no duplicate point.
    public class CheckIfItsAStraightLine
    {
        //trick: Just compute slope from the first point w.r.to all other points. If all the points are on the same line, their slope from the first point will be the same. slope = y2-y1/x2-x1
        public bool CheckStraightLine(int[][] coordinates)
        {
            int[] p1 = coordinates[1];
            int[] p2 = coordinates[0];
            float ConstantSlope = Slope(p1, p2);

            for (int i = 1; i < coordinates.Length; i++)
            {
                int[] point1 = coordinates[i]; //ith data point
                int[] point2 = coordinates[0]; //first data point
                float slope = Slope(point1, point2);
                if (slope != ConstantSlope)
                {
                    return false;
                }
            }
            return true;
        }

        private float Slope(int[] p1, int[] p2)
        {
            if (p1[0] - p2[0] == 0) return 0; //edge case. anything divided by 0 gives infinity
            return (float)(p1[1] - p2[1]) / (p1[0] - p2[0]);
        }
    }
}
