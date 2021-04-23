using System;

/*
The brute-force approach to solving this problem is to simply iterating through every valid choice of ABCD and to evaluate the expression at each iteration, while keeping track of the maximum value. Just return the maximum after considering all possibilities. 

While this solution results in optimal space complexity, it runs in O(n^4) which is pretty bad.

Time : O(n^4) - Where N is the length of the input array
Space: O(1)   - Calculations done in place
*/
public class Program
{
    public int MaximizeExpression(int[] array)
    {
        if (array.Length < 4)
        {
            return 0;
        }

        var max = int.MinValue;

        for (var a = 0; a < array.Length; a++)
        {
            for (var b = a + 1; b < array.Length; b++)
            {
                for (var c = b + 1; c < array.Length; c++)
                {
                    for (var d = c + 1; d < array.Length; d++)
                    {
                        var current = EvaluateExpression(array[a], array[b], array[c], array[d]);
                        max = Math.Max(current, max);
                    }
                }
            }
        }
        return max;
    }

    private int EvaluateExpression(int a, int b, int c, int d)
    {
        return a - b + c - d;
    }
}

