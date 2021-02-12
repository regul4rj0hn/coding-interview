using System;

/*
The previous approach is fine to come up with the formula/algorithm to solve the dynamic programming
problem bottom-up, but once that's done it's easy to see that we don't really need the whole array
and we can just declare two variables for the last two values calculated.
Time : O(n) - Where N is the length of the input array
Space: O(1) - No extra space used
*/
public class Program {
    public static int MaxSubsetSumNoAdjacent (int[] array) {
        if (array.Length == 0) {
            return 0;
        }
        if (array.Length == 1) {
            return array[0];
        }

        int first = array[0];
        int last = Math.Max (array[0], array[1]);

        for (int i = 2; i < array.Length; i++) {
            int current = Math.Max (last, first + array[i]);
            first = last;
            last = current;
        }

        return last;
    }
}