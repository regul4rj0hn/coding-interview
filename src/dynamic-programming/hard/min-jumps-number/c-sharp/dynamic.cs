using System;

// O(n) time | O(1) space
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
