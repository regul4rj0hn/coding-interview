using System.Collections.Generic;

/*
The brute force approach, as with all K-number-sum problem, is to next K for loops and attempt all the possible combinations in the array, which results in O(N^4) time.

Instead, we can calculate the sums of every pair of numbers in the array in O(n^2) time using just two for loops. Then, assuming that we've stored all of these sums in a dictionary, we can find which two sums can be paired together to add up to the target sum.

The numbers summing up to these two sums  will then constitute candidates for valid quadruplets - while making sure that no number was used to generate both of the pairs.

To avoid making that mistake, we can keep track of the pairs by storing the sum as the key, and a list of pairs as the value (as more than 1 pair can sum up to the same key), but only adding a valid pair to our output list when the difference is _already present_ as a key (sum) in our hash table. To achieve this, there's a second loop that takes care of adding things to the hash table that's constrained by the current index/iteration - so no sums will be added twice.

Time : O(n^3) - Worst case, where N is the number of elements on the input array. Might run in O(n^2) on average.
Space: O(n^2) - For the output list of quadruplets and the dictionary to keep track of sums.
*/
public class Program {
    public static List<int[]> FourNumberSum(int[] array, int targetSum) {
        var output = new List<int[]>();
        var pairSums = new Dictionary<int, List<int[]>>();

        for (int i = 1; i < array.Length - 1; i++) {
            for (int j = i + 1; j < array.Length; j++) {
                var sum = array[i] + array[j];
                var diff = targetSum - sum;

                if (pairSums.ContainsKey(diff)) {
                    foreach (var pair in pairSums[diff]) {
                        int[] quadruplet = { pair[0], pair[1], array[i], array[j] };
                        output.Add(quadruplet);
                    }
                }
            }

            for (int k = 0; k < i; k++) {
                var sum = array[i] + array[k];
                int[] pair = { array[k], array[i] };
                if (!pairSums.ContainsKey(sum)) {
                    pairSums.Add(sum, new List<int[]> { pair });
                }
                else {
                    pairSums[sum].Add(pair);
                }
            }
        }

        return output;
    }
}
