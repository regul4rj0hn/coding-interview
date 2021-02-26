using System;
using System.Collections.Generic;

/*
The only difference with the previous approach is that, to improve the time complexity, we are going to be swapping the numbers of the input array in-place. This is a constant time operation, thus resulting in the loop taking N time instead of N * N.

To achieve the above, we keep track of a pointer on each recursive call inside the input list, and we swap the number at its position with the number at "the next position" (recursive step insdie the for loop), and we repeat the process.

The space complexity cannot be optimized with a recursive approach.

Time : O(n.n!) - Where N is the number of elements on the input list. The number of possible permutations for a given list of elements is always N factorial, which coincides with the number of leaves in the recursive call tree. On this approach we are calling the permutate function recursively N times (branches of the tree), and the operations inside the loop take constant time, so 1 * N. That leaves us with N * N! time for the worst case.

Space: O(n.n!) - We need N! space to store the output list of permutation, and N space for the frames of the recusive call stack.
*/
public class Program {
    public static List<List<int>> GetPermutations (List<int> array) {
        var output = new List<List<int>> ();
        Permutate (0, array, output);
        return output;
    }

    private static void Permutate (int i, List<int> input, List<List<int>> output) {
        if (i == input.Count - 1) {
            output.Add (new List<int> (input));
        }
        else {
            for (int j = i; j < input.Count; j++) {
                Swap (input, i, j);
                Permutate (i + 1, input, output);
                Swap (input, i, j);
            }
        }
    }

    private static void Swap (List<int> input, int i, int j) {
        int temp = input[i];
        input[i] = input[j];
        input[j] = temp;
    }
}