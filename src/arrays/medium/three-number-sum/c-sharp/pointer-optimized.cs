using System;
using System.Collections.Generic;

/*
To optimize the brute force approach, first sort the array and define a left pointer and a right pointer to go with our current number.
Knowing that array is now sorted, move the left pointer mentioned one place to the right to get a greater left number and thus a greater sum. Similarly, you moving the right pointer one place to the left will lead to a smaller right number, and thus a smaller sum. 
Depending on the size of each triplet's (current number, left number, right number) sum relative to the target sum, either move the left pointer, the right pointer, or both to obtain a potentially valid triplet.

Time : O(n^2) - Where N is the length of the input array (down to 2 loops)
Space: O(n)   - For the output list with the triplet arrays
*/
public class Program {
    public static List<int[]> ThreeNumberSum (int[] array, int targetSum) {
        var output = new List<int[]> ();
        var triplet = new int[3];
        var tripletSum = 0;

        Array.Sort (array);

        for (int i = 0; i < array.Length - 2; i++) {
            int left = i + 1;
            int right = array.Length - 1;

            while (left < right) {
                tripletSum = array[i] + array[left] + array[right];

                if (tripletSum == targetSum) {
                    triplet = new int[] { array[i], array[left], array[right] };
                    output.Add (triplet);
                    left++;
                    right--;
                }
                if (tripletSum < targetSum) {
                    left++;
                }
                if (tripletSum > targetSum) {
                    right--;
                }
            }
        }

        return output;
    }
}