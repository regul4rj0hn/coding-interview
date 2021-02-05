using System;

/*
Time : O(n) - Where N is the length of the input array
Space: O(1) - No extra space used
*/
public class Program {
    public static int[] FindThreeLargestNumbers (int[] array) {
        var largestThree = new int[] { Int32.MinValue, Int32.MinValue, Int32.MinValue };

        for (int i = 0; i < array.Length; i++) {
            int current = array[i];
            if (largestThree[2] < current) {
                UpdateLargestThree(largestThree, current, 2);
            }
            else if (largestThree[1] < current) {
                UpdateLargestThree(largestThree, current, 1);
            }
            else if (largestThree[0] < current) {
                UpdateLargestThree(largestThree, current, 0);
            }
        }

        return largestThree;
    }

    private static void UpdateLargestThree(int[] largestThree, int target, int index) {
        for (int i = 0; i <= index; i++) {
            if (i == index) {
                largestThree[i] = target;
            }
            else {
                largestThree[i] = largestThree[i+1];
            }
        }
    }
}
