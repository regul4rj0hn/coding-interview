using System;

/*
To solve the edge-case of being forced to sort the output array if it contains negative integers, we keep two pointers on the input array: one for the index where we last inserted a small number, and one for the index of the last large number. Have these two pointers we traverse the input array backwards instead of forward which guarantees us to have the largest number last, even if there are negative numbers on the input. On each iteration, compare the absolute value for the numbers at the smallest index (potentially negative) and largest index: if the negative value is larger square it insert it at the current position (from last to first) and increment the smaller index pointer, otherwise proceed with the last index.
Realize that this algorithm also works if the input sequence doesn't contain any negative numbers as the small index pointer will be fixed to the first position in the array and we will insert the values from last to first, decrementing the large index on each iteration. This effectively reduces the time complexity to be of O(n) because the output array will already be sorted (compared to the brute force approach that requires sorting after it is constructed).

Time : O(n) - Where N is the length of the input array
Space: O(n) - To store the output array of squares
*/
public class Program {

    public int[] SortedSquaredArray (int[] array) {
        var output = new int[array.Length];
        var smallerValueIndex = 0;
        var largerValueIndex = array.Length - 1;

        for (int i = array.Length - 1; i >= 0; i--) {
            var smaller = array[smallerValueIndex];
            var larger = array[largerValueIndex];

            if (Math.Abs (smaller) > Math.Abs (larger)) {
                output[i] = smaller * smaller;
                smallerValueIndex++;
            }
            else {
                output[i] = larger * larger;
                largerValueIndex--;
            }
        }

        return output;
    }
}