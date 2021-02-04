using System;

/*
Time : O(log(n)) - Where N is the length of the input array
Space: O(1)      - No extra space used
*/
public class Program {
    public static int BinarySearch (int[] array, int target) {
        int left = 0;
        int right = array.Length - 1;
        int mid;

        while (left <= right) {
            mid = (left + right) / 2;
            if (array[mid] == target) {
                return mid;
            }

            if (array[mid] > target) {
                right = mid - 1;
            }
            else {
                left = mid + 1;
            }
        }

        return -1;
    }
}