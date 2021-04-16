using System;
using System.Collections.Generic;

/*
Obviously this can be solved with a brute-force approach with two loops simply comparing every pair of indices in the array and counting how many of them represent inversions by comparing their values. That would take O(n^2) time. We can do better taking into account the fact that optimal sorting can be achieved in O(n.log(n)).

We could use an algorithm that's very similar to Merge Sort to determine the number of inversions in any array. First, recursively determine the number of inversions in the left and right halves of an array while sorting them both, just like we would in Merge Sort. Once our two halves are sorted, we merge them together and count the number of inversions required to get to the merged array. Obviously that we need to mutate the input array into sorted order for this to work, so the merge count will actually be sorting our input besides counting.

For merging, consider that whenever we insert an element from the right array before inserting an element from the left array, an inversion or multiple inversions have occurred. This is because elements in the right array are positioned after all elements in the left array, as these two arrays were originally left and right halves of another array. The remaining elements to be inserted from the left array when we insert an element from the right array are all inverted with this right-array element, so we add that to the number of inversions.

The sum between the number of inversions on the left-half, the right-half and the ones that occur while merging is our total number of inversions. 

Time : O(n.log(n)) - Where N is the length of the input array. We are using lineal time to merge the arrays on each iteration (N), and as we are using merge sort the array gets split in half on each iteration (log(N))
Space: O(n)        - This is really N+Log(n) but by the time we get to the merge step and need to store the sorted list, the calls are resolved. i.e. we never have more than log(n) frames in the recursive stack, so we just account for the space required for the merge step only.
*/
public class Program {
    public int CountInversions(int[] array) {
        return CountSubarrayInversions (array, 0, array.Length);
    }

    private int CountSubarrayInversions (int[] array, int start, int end) {
        if (end - start <= 1) {
            return 0;
        }

        var middle = start + (end - start) / 2;
        var leftInversions = CountSubarrayInversions (array, start, middle);
        var rightInversions = CountSubarrayInversions (array, middle, end);
        var mergeSortInversions = CountMergeSortInversions (array, start, middle, end);

        return leftInversions + rightInversions + mergeSortInversions;
    }

    private int CountMergeSortInversions (int[] array, int start, int middle, int end) {
        var sortedList = new List<int>();
        var left = start;
        var right = middle;
        var inversions = 0;

        while (left < middle && right < end) {
            if (array[left] <= array[right]) {
                sortedList.Add (array[left]);
                left++;
            }
            else {
                inversions += middle - left;
                sortedList.Add (array[right]);
                right++;
            }
        }

        for (var i  = left; i < middle; i++) {
            sortedList.Add (array[i]);
        }

        for (var i = right; i < end; i++) {
            sortedList.Add (array[i]);
        }

        for (var i = 0; i < sortedList.Count; i++) {
            var n = sortedList[i];
            array[start + i] = n;
        }

        return inversions;
    }
}
