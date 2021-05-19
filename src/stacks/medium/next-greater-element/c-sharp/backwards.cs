using System;
using System.Collections.Generic;

/*
Same as the other approach, just traversing the input array from right to left instead.

Time : O(n) - Where N is the length of the array
Space: O(n) - For the output / stack data structures
*/
public class Program
{
    public int[] NextGreaterElement(int[] array)
    {
        var output = new int[array.Length];
        Array.Fill(output, -1);
        var stack = new Stack<int>();

        for (var i = 2 * array.Length - 1; i >= 0; i--)
        {
            var circularIndex = i % array.Length;
            while (stack.Count > 0)
            {
                if (stack.Peek() <= array[circularIndex])
                {
                    stack.Pop();
                }
                else
                {
                    output[circularIndex] = stack.Peek();
                    break;
                }
            }
            stack.Push(array[circularIndex]);
        }

        return output;
    }
}
