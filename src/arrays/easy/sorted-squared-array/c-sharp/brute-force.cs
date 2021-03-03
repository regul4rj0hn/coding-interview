using System;

/*
The brute-force approach is really simple as all we need to do is to go through the input array, multiply each number by itself, and store it on the output array.
Realize that the output array needs to be sorted at the end to handle the case of negative integers (which become positive when squared).
E.g. [-5, 1 , 5] is a valid input which will result in an unsorted output. This edge case makes our algorithm suboptimal.

Time : O(n.log(n)) - Where N is the length of the input array, and assuming O(n.log(n)) optimal sorting
Space: O(n)        - To store the output array of squares
*/
public class Program {
    public int[] SortedSquaredArray (int[] array) {
        var output = new int[array.Length];
        for (int i = 0; i < array.Length; i++) {
            output[i] = array[i] * array[i];
        }
        Array.Sort (output);
        return output;
    }
}