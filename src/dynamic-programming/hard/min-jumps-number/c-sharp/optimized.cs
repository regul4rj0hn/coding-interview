using System;

/*
While the dynamic programming approach is good and rather straight forward, it is not optimal in terms of time and space complexity. 
This is a more "clever" solution that I found online. The code is straight forward so just do a trace to understand why it works.

Time : O(n) - Where N is the length of the input array
Space: O(1) - Calculations performed in place
*/
public class Program
{
    public static int MinNumberOfJumps(int[] array)
    {
        if (array.Length == 1)
        {
            return 0;
        }

        var jumps = 0;
        var maxReach = array[0];
        var steps = array[0];

        for (var i = 1; i < array.Length - 1; i++)
        {
            maxReach = Math.Max(maxReach, i + array[i]);
            steps--;
            if (steps == 0)
            {
                jumps++;
                steps = maxReach - i;
            }
        }

        return jumps + 1;
    }
}
