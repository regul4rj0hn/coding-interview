using System;

/*
First of all it is worth pointing out that even a single out-of-order number in the input array can call for a large subarray to have to be sorted, as the number might need to be moved very far away from its original position in order to be in its sorted position.
We start by finding the smallest and largest numbers that are out of order in a single pass through the input array. Then we find the final sorted positions for these two numbers in the array.

This approach will give us the extremities of the smallest subarray that needs to be sorted to return.

Time : O(n) - Where N is the length of the input array
Space: O(1) - No additional data structures used
*/
public class Program {
    public static int[] SubarraySort(int[] array) {
        var minOutOfOrder = int.MaxValue;
        var maxOutOfOrder = int.MinValue;

        for (var i = 0; i < array.Length; i++) {
            var num = array[i];
            if (IsOutOfOrder (i, num, array)) {
                minOutOfOrder = Math.Min (minOutOfOrder, num);
                maxOutOfOrder = Math.Max (maxOutOfOrder, num);
            }
        }

        if (minOutOfOrder == int.MaxValue) {
            return new int[] { -1, -1 };
        }

        var subarrayLeftIdx = 0;
        while (minOutOfOrder >= array[subarrayLeftIdx]) {
            subarrayLeftIdx++;
        }
        var subarrayRightIdx = array.Length - 1;
        while (maxOutOfOrder <= array[subarrayRightIdx]) {
            subarrayRightIdx--;
        }

        return new int[] { subarrayLeftIdx, subarrayRightIdx };
    }

    public static bool IsOutOfOrder (int i, int n, int[] array) {
        if (i == 0) {
            return n > array[i + 1];
        }
        if (i == array.Length - 1) {
            return n < array[i - 1];
        }
        return n > array[i + 1] || n < array[i - 1];
    }
}
