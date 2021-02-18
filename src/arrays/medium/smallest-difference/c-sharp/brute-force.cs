using System;

/*
Time : O(n.m) - Where N is the length of the first input array and M the length of the second input array
Space: O(1)   - Compare in place, no extra space
*/
public class Program {
    public static int[] SmallestDifference (int[] arrayOne, int[] arrayTwo) {
        int[] output = new int[2];
        int smallest = int.MaxValue;

        for (int i = 0; i < arrayOne.Length; i++) {
            for (int j = 0; j < arrayTwo.Length; j++) {
                int abs = Math.Abs (arrayOne[i] - arrayTwo[j]);
                if (abs < smallest) {
                    smallest = abs;
                    output = new int[] { arrayOne[i], arrayTwo[j] };
                }
            }
        }

        return output;
    }
}