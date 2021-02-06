using System;

/*
Time : O(n^2) - Where N is the length of the input array, best case O(N) when it's already sorted
Space: O(1)   - No extra space used, sort in place
*/
public class Program {
    public static int[] BubbleSort (int[] array) {
        bool isSorted = false;
        int max = array.Length - 1;
        int current;

        while (!isSorted) {
            isSorted = true;
            for (int i = 0; i < max; i++) {
                if (array[i] >= array[i + 1]) {
                    current = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = current;
                    isSorted = false;
                }
            }
            max--;
        }
        return array;
    }
}