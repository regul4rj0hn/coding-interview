using System;

/*
    Time: O(n^2) - IndexOf() is also O(n) this is just a bit cleaner
    Space: O(1) - No additional structures
*/
public class Program {
    public static int[] TwoNumberSum (int[] array, int targetSum) {
        for (int i = 0; i < array.Length; i++) {
            var compIndex = Array.IndexOf (array, targetSum - array[i]);

            if (compIndex != i && compIndex != -1) {
                return new int[] { array[i], array[compIndex] };
            }
        }
        return new int[0];
    }
}
