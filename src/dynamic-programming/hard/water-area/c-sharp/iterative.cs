using System;

/*
In order to calculate the amount of water above a single point in the input array, you must know the height of the tallest pillar to its left and the height of the tallest pillar to its right.
If a point can hold water above it, then the smallest of the two heights mentioned above, minus the height at that respective point should result in the target amount of water above it.

If we build an array of the left and right max heights for each point in the heights input array, we are able to compute the final amount of water above each point in just two loops over the heights array.
After that, a final loop is required to sum the total water to return.

Time : O(n) - Where N is the length of the input list
Space: O(n) - For storing the max heights list
*/
public class Program
{
    public static int WaterArea(int[] heights)
    {
        var max = new int[heights.Length];

        var leftMax = 0;
        for (var i = 0; i < heights.Length; i++)
        {
            var height = heights[i];
            max[i] = leftMax;
            leftMax = Math.Max(leftMax, height);
        }

        var rightMax = 0;
        for (var i = heights.Length - 1; i >= 0; i--)
        {
            var height = heights[i];
            var minHeight = Math.Min(rightMax, max[i]);
            if (height < minHeight)
            {
                max[i] = minHeight - height;
            }
            else
            {
                max[i] = 0;
            }
            rightMax = Math.Max(rightMax, height);
        }

        var total = 0;
        for (var i = 0; i < heights.Length; i++)
        {
            total += max[i];
        }

        return total;
    }
}
