using System;

/*
Time : O(log(n)) - Where N is the length of the input array (eliminating half of the input on each iteration)
Space: O(log(n)) - Worst case for the recursive call stack memory (use iterative)
*/
public class Program {
    public static int BinarySearch (int[] array, int target) {
        return Search (array, target, 0, array.Length - 1);
    }

    private static int Search (int[] array, int target, int left, int right) {
        if (left > right) {
            return -1;
        }

        int mid = (left + right) / 2;
        int match = array[mid];

        if (match == target) {
            return mid;
        }
        else if (match < target) {
            return Search (array, target, mid + 1, right);
        }
        else {
            return Search (array, target, left, mid - 1);
        }
    }
}