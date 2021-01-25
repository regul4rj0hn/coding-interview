using System;

/*
    Time: O(n^2) - Two nested for loops
    Space: O(1) - No extra storage
*/
public class Program {
    public static int[] TwoNumberSum (int[] array, int targetSum) {
        for (int i = 0; i < array.Length; i++) {
            for (int j = 0; j < array.Length; j++) {
                if (j != i && array[i] + array[j] == targetSum) {
                    return new int[] { array[i], array[j] };
                }
            }
        }
        return new int[0];
    }
}