using System;
using System.Collections.Generic;

/*
A permutation is defined as the way in which a set of things can be ordered. 

The general idea is that in order to construct a permutation, we can pick a number from our list to be the first number and remove it from the input, then we can pick the second number from the remaining list (without the first number) to be the second number on the permutation, so on and so forth we can repeat the process until we exhaust all of our input list numbers.

At that point, we will have constructed a valid permutation list, and we can add it to the output list.

Time : O(n^2.n!) - Where N is the number of elements on the input list. The number of possible permutations for a given list of elements is always N factorial, which coincides with the number of leaves in the recursive call tree. The thing is that we are going to be calling the permutate function recursively N times (branches of the tree), and the operations inside the loop (Remove/Add nodes) are done in lineal time, so N * N. That leaves us with N^2 * N! time for the worst case.

Space: O(n.n!)   - We need N! space to store the output list of permutation, and N space for the frames of the recusive call stack.
*/
public class Program {
    public static List<List<int>> GetPermutations (List<int> array) {
        var output = new List<List<int>> ();
        Permutate (array, new List<int> (), output);
        return output;
    }

    private static void Permutate (List<int> input, List<int> permutation, List<List<int>> output) {
        if (input.Count == 0 && permutation.Count > 0) {
            output.Add (permutation);
        } 
        else {
            foreach (int i in input) {
                var newInput = new List<int> (input);
                newInput.Remove (i);
                var nextPerm = new List<int> (permutation);
                nextPerm.Add (i);
                Permutate (newInput, nextPerm, output);
            }
        }
    }
}