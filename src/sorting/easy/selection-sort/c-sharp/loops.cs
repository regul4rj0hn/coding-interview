using System;

/*
Time : O(n^2) - Where N is the length of the input array, best case still O(n^2), so it sucks 
Space: O(1)   - No extra space used, sort in place
*/
public class Program {
    public static int[] SelectionSort (int[] array) {
        int minSorted = 0;
        int selected;

        while (minSorted < array.Length) {
            selected = minSorted;
            for (int i = minSorted; i < array.Length; i++) {
                if (array[i] < array[selected]) {
                    selected = i;
                }
            }
            SwapInPlace (array, minSorted, selected);
            minSorted++;
        }
        return array;
    }

    private static void SwapInPlace (int[] array, int left, int right) {
        int tmp = array[left];
        array[left] = array[right];
        array[right] = tmp;
    }
}