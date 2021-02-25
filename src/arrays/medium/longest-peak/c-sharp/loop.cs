using System;

/*
Iterate through the array from left to right, and treat every integer as the potential tip of a peak. To be the tip of a peak, an integer has to be strictly greater than its adjacent integers.

As you iterate through the array from left to right, whenever you find the tip of a peak, expand outwards from the tip until you no longer have a peak. 

Given what peaks look like and how many peaks can therefore fit in an array, this process results in a linear-time algorithm.

Time : O(n) - Where N is the length of the input array
Space: O(1) - We check the sequence in-place
*/
public class Program {
    public static int LongestPeak (int[] array) {
        int highestPeak = 0;
        int i = 1;

        while (i < array.Length - 1) {
            if (!IsPeak (array[i - 1], array[i], array[i + 1])) {
                i++;
            }
            else {
                int left = i - 2;
                while (left >= 0 && array[left] < array[left + 1]) {
                    left--;
                }

                int right = i + 2;
                while (right < array.Length && array[right] < array[right - 1]) {
                    right++;
                }

                int currentPeak = right - left - 1;
                highestPeak = currentPeak > highestPeak ? currentPeak : highestPeak;
                i = right;
            }
        }

        return highestPeak;
    }

    private static bool IsPeak (int left, int center, int right) {
        return left < center && center > right;
    }
}