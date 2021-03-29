using System;

/*
Same approach as with the recursive implementation but iterative.
Uses an array that stores the number of steps required to get to an given height represented by the index.

Time : O(k.n) - Where N is the the height of the staircase and K is the number of max steps
Space: O(n)   - For the number of ways array
*/
public class Program
{
    public int StaircaseTraversal(int height, int maxSteps)
    {
        var ways = new int[height + 1];
        ways[0] = 1;
        ways[1] = 1;

        for (var currentHeight = 2; currentHeight < height + 1; currentHeight++)
        {
            var step = 1;
            while (step <= maxSteps && step <= currentHeight)
            {
                ways[currentHeight] = ways[currentHeight] + ways[currentHeight - step];
                step++;
            }
        }

        return ways[height];
    }
}
