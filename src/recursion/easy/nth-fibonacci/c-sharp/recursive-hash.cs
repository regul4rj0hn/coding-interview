using System;
using System.Collections.Generic;

/*
Time : O(n) - Calculate all fibs for N once, asumming constant time to search the hash
Space: O(n) - Need to store the complete list of N in the hash
*/
public class Program {
    public static int GetNthFib (int n) {
        var store = new Dictionary<int, int> ();
        store.Add (1, 0);
        store.Add (2, 1);
        return GetFib (n, store);
    }

    private static int GetFib (int n, Dictionary<int, int> store) {
        if (store.ContainsKey (n)) {
            return store[n];
        }
        else {
            store.Add (n, GetFib (n - 1, store) + GetFib (n - 2, store));
            return store[n];
        }
    }
}