using System;

/*
Time : O(n^2) - Where N is the length of the input array, best case O(N) when it's already sorted
Space: O(1)   - No extra space used, sort in place
*/
public class Program {
    public static int[] InsertionSort (int[] array) {
        int maxSorted = 0;

        while (maxSorted < array.Length) {
            for (int i = maxSorted; i > 0; i--) {
                if (array[i] < array[i - 1]) {
                    SwapInPlace (array, i, i - 1);
                }
            }
            maxSorted++;
        }

        return array;
    }

    private static void SwapInPlace (int[] array, int first, int second) {
        int tmp = array[first];
        array[first] = array[second];
        array[second] = tmp;
    }
}