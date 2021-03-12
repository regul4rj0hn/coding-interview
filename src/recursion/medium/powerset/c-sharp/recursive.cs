using System;
using System.Collections.Generic;

/*
The recursive solution is very similar to the iterative one, with the difference that we will need a helper function to pass in the current index as a pointer (to avoid creating subarrays which is of O(n)):
 - The base case is when our index is 0, that's where we initialize with the empty subset.
 - The recursive step is calculating Powerset of the output list, but cutting one element from the end of the list (which means we are going to be calling all the way to the base case, thus initializing the empty subset)
 - Then we iterate through the current output list and add all the new subsets with the target element.

The time and space complexity stays the same.

Time : O(n.2^n) - Where N is the the number of elements on the input list
Space: O(n.2^n) - For the output list with all the possible sets
*/
public class Program
{
    public static List<List<int>> Powerset(List<int> array)
    {
        return Powerset(array, array.Count - 1);
    }

    private static List<List<int>> Powerset(List<int> array, int i)
    {
        if (i < 0)
        {
            return new List<List<int>>() { new List<int>() };
        }

        var element = array[i];
        var output = Powerset(array, i - 1);
        var length = output.Count;

        for (int j = 0; j < length; j++)
        {
            var subset = new List<int>(output[j]);
            subset.Add(element);
            output.Add(subset);
        }

        return output;
    }
}
