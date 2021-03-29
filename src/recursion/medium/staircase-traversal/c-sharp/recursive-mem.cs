using System;
using System.Collections.Generic;

/*
Dynamic Programming approach passing a memoize to store and avoid recalculating the number of ways that we've already computed on previous recursive calls.

Time : O(k.n) - Where N is the the height of the staircase and K is the number of max steps
Space: O(n)   - For the frames of the recursive call stack and the memoize
*/
public class Program
{
    public int StaircaseTraversal(int height, int maxSteps)
    {
        var memoize = new Dictionary<int, int>();
        memoize[0] = 1;
        memoize[1] = 1;
        return NumberOfWaysToTop (height, maxSteps, memoize);
    }

    private int NumberOfWaysToTop (int height, int maxSteps, Dictionary<int, int> mem)
    {
        if (mem.ContainsKey(height))
        {
            return mem[height];
        }

        var ways = 0;
        for (var step = 1; step < Math.Min(height, maxSteps) + 1; step++)
        {
            ways += NumberOfWaysToTop (height - step, maxSteps, mem);
        }

        mem[height] = ways;

        return ways;
    }
}

