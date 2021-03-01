using System;

/*
From the left-and-right approach it's easy to see that we don't actually need to store 2 extra arrays, or run the final loop to multiply the two.
We can just loop once through the input array from left to right and store the "current running product" to the left on the output array.
After that's done, we run once more through the input from right to left, and we multiply the current running product to the right in place, and
we store that directly on the output array.

Time : O(n) - Where N is the length of the input list
Space: O(n) - For the output list
*/
public class Program {
    public int[] ArrayOfProducts (int[] array) {
        var output = new int[array.Length];

        int currentLeft = 1;
        for (int i = 0; i < array.Length; i++) {
            output[i] = currentLeft;
            currentLeft *= array[i];
        }

        int currentRight = 1;
        for (int i = array.Length - 1; i >= 0; i--) {
            output[i] *= currentRight;
            currentRight *= array[i];
        }

        return output;
    }
}