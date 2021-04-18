using System;
using System.Linq;

/*
Time : O(n.log(n)) - Where N is the length of the input array
Space: O(n.log(n)) - For the frames on the recursive call stack
*/
public class Program {
    public static int[] MergeSort(int[] array) {
        if (array.Length <= 1) {
            return array;
        }

        var mid = array.Length / 2;
        var left = array.Take(mid).ToArray();
        var right = array.Skip(mid).ToArray();

        return MergeSortHalves (MergeSort(left), MergeSort(right));
    }

    private static int[] MergeSortHalves (int[] left, int[] right) {
        var sorted = new int[left.Length + right.Length];
        var i = 0;
        var j = 0;
        var k = 0;

        while (i < left.Length && j < right.Length) {
            if (left[i] <= right[j]) {
                sorted[k++] = left[i++];
            }
            else {
                sorted[k++] = right[j++];
            }
        }
        while (i < left.Length) {
            sorted[k++] = left[i++];
        }
        while (j < right.Length) {
            sorted[k++] = right[j++];
        }

        return sorted;
    }
}
