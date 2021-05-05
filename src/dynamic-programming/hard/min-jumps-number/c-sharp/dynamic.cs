using System;

/*
To approach the solution we create a jumps array of the length of our input array. Initialize the first index with 0 (to get from 0 to 0 we need 0 jumps) and the rest of the array with infinity.
We start looping through the input array index 1 to calculate the minimum number of jumps for each index, incrementally solving the problem at each step. On each iteration we check whether the value of array[J] (our running index) is greater than or equal to I - J indices. This tell us whether we can jump to our target index or not. If so, to determine the minimum number of jumps for index I (jumps[i]) we take the minimum between either number of jumps between what we stored jumps[J] + 1, or the value current value of jumps[J].

Our solution of the minimum jumps to get to the end will be stored at the last index of our jumps array.

Time : O(n^2) - Where N is the length of the input array
Space: O(n)   - For incrementally constructing the array of jumps to calculate the solution
*/
public class Program
{
    public static int MinNumberOfJumps(int[] array)
    {
        var jumps = new int[array.Length];
        Array.Fill(jumps, int.MaxValue);
        jumps[0] = 0;

        for (var i = 1; i < array.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (array[j] >= i - j)
                {
                    jumps[i] = Math.Min(jumps[j] + 1, jumps[i]);
                }
            }
        }

        return jumps[jumps.Length - 1];
    }
}
