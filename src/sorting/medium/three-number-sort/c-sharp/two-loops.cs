using System;

/*
This approach takes advantage of the fact that the order array only has three elements, so when both the left and the right sides of the input array are swapped into their final possition, the only possible alternative is that the elements in the middle are also ordered and in their final possition.

We can conceptually split the original array into three subarrays and move elements of each unique value into the correct subarray. To do so we keep track of the respective starting indices of these subarrays.
Keeping that in mind, the problem can be solved either with two passes through the input array or with a single pass. For this approach with two passes through the array:
 - Position the first ordered element during the first pass and the third ordered element during the second pass.
 - Swap elements from the left side of the array whenever you encounter the first element, and swap elements from the right side of the array whenever you encounter the third element.
 - Keep track of where we last placed a first element or a third element.

Time : O(n) - Where N is the length of the input array that we need to sort
Space: O(1) - No extra space used, sort in place
*/
public class Program
{
    public int[] ThreeNumberSort (int[] array, int[] order)
    {
        var firstOrder = order[0];
        var thirdOrder = order[2];

        var firstPos = 0;
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] == firstOrder)
            {
                Swap (firstPos, i, array);
                firstPos++;
            }
        }

        var thridPos = array.Length - 1;
        for (var i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] == thirdOrder)
            {
                Swap (thridPos, i, array);
                thridPos--;
            }
        }

        return array;
    }

    private void Swap (int i, int j, int[] array)
    {
        var tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
}