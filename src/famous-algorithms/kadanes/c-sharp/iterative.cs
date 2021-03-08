using System;

/*
Consider that sub-arrays can only be formed with adjacent numbers. The main complication of this problem comes with negative numbers: all the numbers on the input array were positive we just take the full array as a subset.

We use dynamic programming to divide the problem into a smaller problem. Traverse the array summing up all the consecutive numbers, for each index in the input array we are going to take the MAX number between:
 - The previous subarray sum (i.e. sum of all idexes that are between the last index selected and the current number), plus the current number (even if it is negative).
 - Just the number at the current index, and "select" the current index as the beginning of our new subarray.

While looping through the array with this approach, we keep track of the "maximum subarray sum" as we calculate them on each iteration, so that we can just return that value when we are done.

Theory: https://en.wikipedia.org/wiki/Maximum_subarray_problem

Time : O(n) - Where N is the length of the input array
Space: O(1) - We check the sequence in-place
*/
public class Program {
    public static int KadanesAlgorithm (int[] array) {
        var currentMax = array[0];
        var output = array[0];
        
        for (int i = 1; i < array.Length; i++) {
            var num = array[i];
            currentMax = Math.Max (num, currentMax + num);
            output = Math.Max (output, currentMax);
        }
        
        return output;
    }
}
