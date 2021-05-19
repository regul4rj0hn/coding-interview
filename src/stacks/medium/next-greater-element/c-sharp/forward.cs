using System;
using System.Collections.Generic;

/*
The brute-force approach is quite easy just traverse the input array looking for the next greater element N times, once for each index in the output array, but the time complexity of that solution is O(n^2).

One approach to solve this problem is to push onto a stack the indices of elements for which we haven't yet found the next greater element. We need to loop through the array twice (since it's circular), and compare the value of the current element in the array to the one represented by the index on top of the stack. If the element on the top of the stack is smaller than the current element, then the current element is next greater element for the top-of-stack index, so we can pop the index off the top of the stack and use it to store the current element in the correct position in the output array. 

We then pop elements repeatedly off the top of the stack until the current element is no longer greater than the top-of-stack element. At this point, we add the index of the current element to the top of the stack, and continue iterating through the array, repeating the same process.

Time : O(n) - Where N is the length of the array
Space: O(n) - For the output / stack data structures
*/
public class Program {
    public int[] NextGreaterElement(int[] array) {
        var output = new int[array.Length];
        Array.Fill(output, -1);
        var stack = new Stack<int>();

        for (var i = 0; i < 2 * array.Length; i++) {
            var circularIndex = i % array.Length;
            while (stack.Count > 0 && array[stack.Peek()] < array[circularIndex]) {
                var top = stack.Pop();
                output[top] = array[circularIndex];
            }
            stack.Push(circularIndex);
        }

        return output;
    }
}
