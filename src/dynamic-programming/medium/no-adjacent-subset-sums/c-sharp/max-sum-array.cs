using System;

/*
Time : O(n) - Where N is the length of the input array
Space: O(n) - To store the maximum sums on each iteration
*/
public class Program {
    public static int MaxSubsetSumNoAdjacent (int[] array) {
        if (array.Length == 0) {
            return 0;
        }

        int[] sums = new int[array.Length];
        sums[0] = array.Length > 0 ? array[0] : 0;

        if (array.Length > 1) {
            sums[1] = Math.Max (sums[0], array[1]);
        }

        for (int i = 2; i < array.Length; i++) {
            sums[i] = Math.Max (sums[i - 1], sums[i - 2] + array[i]);
        }

        return sums[array.Length - 1];
    }
}