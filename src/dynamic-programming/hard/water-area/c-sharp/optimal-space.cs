using System;

/*
We don't really need to store the information in a dedicated max pilar array. 
We can instead have two pointers defined from the start and end of the array, and traverse the input array once, comparing on the fly what the maximum area for each index would be, while keeping track of that value. 

Time : O(n) - Where N is the length of the input list
Space: O(1) - Calculations done in-place, no extra space required
*/
public class Program
{
    public static int WaterArea(int[] heights)
    {
        if (heights.Length == 0)
        {
            return 0;
        }

        var leftIdx = 0;
        var rightIdx = heights.Length - 1;
        var leftMax = heights[leftIdx];
        var rightMax = heights[rightIdx];
        var surfaceArea = 0;

        while (leftIdx < rightIdx)
        {
            if (heights[leftIdx] < heights[rightIdx])
            {
                leftIdx++;
                leftMax = Math.Max(leftMax, heights[leftIdx]);
                surfaceArea += leftMax - heights[leftIdx];
            }
            else
            {
                rightIdx--;
                rightMax = Math.Max(rightMax, heights[rightIdx]);
                surfaceArea += rightMax - heights[rightIdx];
            }
        }

        return surfaceArea;
    }
}
