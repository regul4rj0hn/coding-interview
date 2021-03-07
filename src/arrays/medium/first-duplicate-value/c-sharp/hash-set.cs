using System;
using System.Collections.Generic;

/*
Pretty intuitive solution, just store each item on a hash table and traverse the sequence once, checking if you already seen the item on the hash.
If the item is found in the hash then it must mean it's repeated so we can just return it, otherwise we add it and continue.
If we added all elements without returning, then it means that there are no dups.

Time : O(n) - Where N is the length of the input array (assuming constant hash seek)
Space: O(n) - Worst case, when there are no duplicates, every element will be in the hash
*/
public class Program {
    public int FirstDuplicateValue (int[] array) {
        var hash = new HashSet<int> ();
        foreach (int i in array) {
            if (hash.Contains (i)) {
                return i;
            }
            hash.Add (i);
        }
        return -1;
    }
}