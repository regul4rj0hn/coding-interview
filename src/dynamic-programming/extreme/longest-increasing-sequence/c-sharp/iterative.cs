using System;
using System.Collections.Generic;

/*
We define two arrays:
 - sequences: where values represent the index of the smallest numbers in the input array that can end a subsequence for a given (index) length. Initialized with minus infinity as a delimiter.
 - lengths: where the values for each index represents the max length of strictly-increasing subsequences _up until that index_. Initialized with ones (an array with 1 element is a valid subsequence).

We need to evaluate all subsequences, so with two nested loops we traverse the input array. For each position we determine what's the length L of the longest increasing subsequence that we can build ending with that number. We calculate the two  values (indexes to store on sequence and length info arrays) on each step by comparing:
 (1) the current value with that of our subsequence "end" value, and 
 (2) determine whether the subsequence being analized is longer than previous one or not, by using the lengths recorded on previous iterations. 
We increasingly approach the solution using dynamic programming. Additionally, to avoid having to traverse the lengths array to find the longest one when we are done, we keep track of the index of where value with the maximum length recorded so far is. 

Once that we have the sequences array built, along with the index of the value where the maximum length subsequence ends, we construct our output subsequence array by traversing our input array backwards using our gathered information to insert, from last to first, the values at the indexes stored in our sequences array. I.e. the secuences array will hold the "history" that we need to use to build our output.

Time : O(n^2) - Where N is the length of the input array
Space: O(n)   - For gathering information about our input array subsequences and the output subsequence to return
*/
public class Program {
    public static List<int> LongestIncreasingSubsequence (int[] array) {
        var sequences = new int[array.Length];
        Array.Fill (sequences, int.MinValue);
        var lengths = new int[array.Length];
        Array.Fill (lengths, 1);
        var maxLengthIndex = 0;

        for (var i = 0; i < array.Length; i++) {
            var subsequenceEndValue = array[i];
            for (var j = 0; j < i; j++) {
                var currentValue = array[j];
                if (currentValue < subsequenceEndValue && lengths[j] + 1 >= lengths[i]){
                    lengths[i] = lengths[j] + 1;
                    sequences[i] = j;
                }
            }
            maxLengthIndex = lengths[i] >= lengths[maxLengthIndex] ? i : maxLengthIndex;
        }

        return BuildSequence (array, sequences, maxLengthIndex);
    }

    private static List<int> BuildSequence (int[] input, int[] sequences, int maxLength) {
        var output = new List<int>();

        while (maxLength != int.MinValue) {
            output.Insert(0, input[maxLength]);
            maxLength = sequences[maxLength];
        }

        return output;
    }
}
