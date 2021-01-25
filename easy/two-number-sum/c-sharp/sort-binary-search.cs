using System;

/*
    Time: O(n.log(n)) - For sorting
    Space: O(1) - No additional structures
*/
public class Program {
    public static int[] TwoNumberSum (int[] array, int targetSum) {
        Array.Sort (array);
        var left = 0;
        var right = array.Length - 1;

        // Binary search
        while (left < right) {
            int sum = array[left] + array[right];
            if (sum == targetSum) {
                return new int[] { array[right], array[left] };
            } else if (sum < targetSum) {
                left++;
            } else if (sum > targetSum) {
                right--;
            }
        }

        return new int[0];
    }
}