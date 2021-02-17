using System;
using System.Collections.Generic;

/*
Need to sort the array first so that we meet the requirement of the output array being sorted.

Time : O(n^3) - Where N is the length of the input array (3 nested for-loops)
Space: O(n)   - For the output list with the triplet arrays
*/
public class Program {
    public static List<int[]> ThreeNumberSum (int[] array, int targetSum) {
        var output = new List<int[]> ();
        var triplet = new int[3];
        var tripletSum = 0;

        Array.Sort (array);

        for (int i = 0; i < array.Length - 2; i++) {
            for (int j = i + 1; j < array.Length - 1; j++) {
                for (int k = j + 1; k < array.Length; k++) {
                    tripletSum = array[i] + array[j] + array[k];
                    if (tripletSum == targetSum) {
                        triplet = new int[] { array[i], array[j], array[k] };
                        output.Add (triplet);
                    }
                }
            }
        }

        return output;
    }
}