using System;
using System.Collections.Generic;

/*
While the time and space complexity stays the same, this solution is a lot more intuitive than the recursive one.
Start the powerset with the empty set, and then mark the length of the output set so that we can incrementally add subsets to it.
Notice that on each iteration we start the subset with the output list and grab the subsets already in it, and create new subsets adding the next element from the input array.

It's easy to see that on every iteration we are doubling the previous number of subsets, so that's 2^N, and that the subsets take us at most N/2 iterations to make (which converges to N). Thus the n.2^n time and space complexity.

Time : O(n.2^n) - Where N is the the number of elements on the input list
Space: O(n.2^n) - For the output list with all the possible sets
*/
public class Program
{
    public static List<List<int>> Powerset(List<int> array)
    {
        var output = new List<List<int>>() { new List<int>() };

        foreach (var element in array)
        {
            var length = output.Count;
            for (int i = 0; i < length; i++)
            {
                var subset = new List<int>(output[i]);
                subset.Add(element);
                output.Add(subset);
            }
        }

        return output;
    }
}
