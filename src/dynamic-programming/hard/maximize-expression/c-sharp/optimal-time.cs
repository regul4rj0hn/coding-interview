using System;
using System.Collections.Generic;

/*
The dynamic programming approach below solves the problem in O(n) time complexity at the cost of using N space to keep track of intermediate calculations.

We start by finding the maximum possible value of A at each index in the array and store all of these values in an intermediate list. Then we use them to help you determine the maximum possible value of (A - B) at each index, (A - B + C) using the results from (A - B), and finally with (A - B + C - D) using the results from the previous (A - B + C).

Once that we have the a - b + c - d maximums, the expression maximum will be store in the last position of that list.

Time : O(n) - Where N is the length of the input array
Space: O(n) - To store the intermediate list structures
*/
public class Program
{
    public int MaximizeExpression(int[] array)
    {
        if (array.Length < 4)
        {
            return 0;
        }

        var aMax = new List<int> { array[0] };
        var aMinusBMax = new List<int> { int.MinValue };
        var aMinusBPlusCMax = new List<int> { int.MinValue, int.MinValue };
        var aMinusBPlusCMinusDMax = new List<int> { int.MinValue, int.MinValue, int.MinValue };

        for (var i = 1; i < array.Length; i++)
        {
            var max = Math.Max(aMax[i - 1], array[i]);
            aMax.Add(max);
        }
        for (var i = 1; i < array.Length; i++)
        {
            var max = Math.Max(aMinusBMax[i - 1], aMax[i - 1] - array[i]);
            aMinusBMax.Add(max);
        }
        for (var i = 2; i < array.Length; i++)
        {
            var max = Math.Max(aMinusBPlusCMax[i - 1], aMinusBMax[i - 1] + array[i]);
            aMinusBPlusCMax.Add(max);
        }
        for (var i = 3; i < array.Length; i++)
        {
            var max = Math.Max(aMinusBPlusCMinusDMax[i - 1], aMinusBPlusCMax[i - 1] - array[i]);
            aMinusBPlusCMinusDMax.Add(max);
        }

        return aMinusBPlusCMinusDMax[aMinusBPlusCMinusDMax.Count - 1];
    }
}
