using System;

/*
The brute force approach  is straight forward, but pretty inefficient in time complexity.
Basically 2 nested loops multiplying everything but the current element storing the result on the output array.

An easy way to optimize this would be to run through the input array once and store the total product,
and then run through it a second time and the output result would be the total divided by the current element.
This would be 2N, so effectively O(n) time complexity but the problem states that we cannot use division.

Time : O(n^2) - Where N is the length of the input list
Space: O(n)   - To store the output list
*/
public class Program {
    public int[] ArrayOfProducts (int[] array) {
        var output = new int[array.Length];

        for (int i = 0; i < array.Length; i++) {
            var mult = 1;
            for (int j = 0; j < array.Length; j++) {
                mult = i != j ? mult * array[j] : mult;
            }
            output[i] = mult;
        }

        return output;
    }
}