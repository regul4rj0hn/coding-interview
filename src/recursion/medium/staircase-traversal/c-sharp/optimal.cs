using System;
using System.Collections.Generic;

/*
Have a list structure to store the number of ways to get to the previous steps.
Define a "sliding window" over that list for our last K calculations using two pointers. The window is always kept to be of maxSteps size. 
The number of ways in which we can get to the next step will be the sum of all the previous number of ways that fall inside our window.
In other words, on each iteration we slide our window one slot: substract the number of ways that's now out of our window and add the one calculated on the previous iteration.
We return the number of ways for our last calculation (so where indexe = height)

Time : O(n) - Where N is the the height of the staircase
Space: O(n) - For the number of ways array
*/
public class Program
{
    public int StaircaseTraversal (int height, int maxSteps)
    {
        var waysCount = 0;
        var ways = new List<int>();
        ways.Add (1);

        for (var currentHeight = 1; currentHeight < height + 1; currentHeight++)
        {
            var start = currentHeight - maxSteps - 1;
            var end = currentHeight - 1;

            if (start >= 0)
            {
                waysCount -= ways[start];
            }

            waysCount += ways[end];
            ways.Add (waysCount);
        }

        return ways[height];
    }
}
