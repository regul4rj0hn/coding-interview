using System;

/*
The basic algorithm is exactly the same as with the recursive approach, only that we use a memoize of ways to store the result number of ways it takes us to reach each position in the form of a matrix. By doing so we avoid re-calculating the ways for previous steps.

This is the actual "dynamic programming" approach, and reduces the time complexity to N*M at the expense of some added space complexity.

Time : O(n.m) - Where N is the width and M is the height of the graph
Space: O(n.m) - To store the number of ways we have to reach each position
*/
public class Program
{
    public int NumberOfWaysToTraverseGraph (int width, int height)
    {
        var ways = new int[height + 1, width + 1];

        for (var widthIndex = 1; widthIndex < width + 1; widthIndex++)
        {
            for (var heightIndex = 1; heightIndex < height + 1; heightIndex++)
            {
                if (widthIndex == 1 || heightIndex == 1)
                {
                    ways[heightIndex, widthIndex] = 1;
                }
                else
                {
                    var waysLeft = ways[heightIndex, widthIndex - 1];
                    var waysUp = ways[heightIndex - 1, widthIndex];
                    ways[heightIndex, widthIndex] = waysLeft + waysUp;
                }
            }
        }

        return ways[height, width];
    }
}
