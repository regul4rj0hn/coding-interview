using System.Collections.Generic;

/**
    Time: O(n) - Search once, Hash search is constant.
    Space: O(n) - For the HashMap
**/
public class Program {
    public static int[] TwoNumberSum (int[] array, int targetSum) {
        var store = new HashSet<int> ();

        foreach (int n in array) {
            var match = targetSum - n;
            if (store.Contains (match)) {
                return new int[] { n, match };
            } else {
                store.Add (n);
            }
        }

        return new int[0];
    }
}