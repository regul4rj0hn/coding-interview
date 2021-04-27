using System;

/*
Like quicksort, quickselect has good average performance, but is sensitive to the pivot that is chosen. If good pivots are chosen, meaning ones that consistently decrease the search set by a given fraction, then the search set decreases in size exponentially and by induction (or summing the geometric series) one sees that performance is linear, as each step is linear and the overall time is a constant time (depending on how quickly the search set reduces).
However, if bad pivots are consistently chosen, such as decreasing by only a single element each time, then worst-case performance is quadratic: O(n^2). This occurs for example in searching for the maximum element of a set, using the first element as the pivot, and having sorted data.

Best   : O(n)   time | O(1) space
Average: O(n)   time | O(1) space
Worst  : O(n^2) time | O(1) space
*/
public class Program {
    public static int Quickselect(int[] array, int k) {
        return Quickselect (array, 0, array.Length - 1, k - 1);
    }

    private static int Quickselect (int[] array, int start, int end, int pos) {
        while (true) {
            if (start > end) {
                throw new Exception("Invalid position");
            }
            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right) {
                if (array[left] > array[pivot] && array[right] < array[pivot]) {
                    Swap (left, right, array);
                }
                if (array[left] <= array[pivot]) {
                    left++;
                }
                if (array[right] >= array[pivot]) {
                    right--;
                }
            }

            Swap (pivot, right, array);

            if (right == pos) {
                return array[right];
            }
            if (right < pos) {
                start = right + 1;
            }
            else {
                end = right - 1;
            }
        }
    }

    private static void Swap (int i, int j, int[] array) {
        int tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
}
