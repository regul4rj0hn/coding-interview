using System;
using System.Collections.Generic;

/**
    Time: O(n) - Worst case runs through the whole list once
    Space: O(1) - No extra storage
**/
public class Program {
    public static bool IsValidSubsequence (List<int> array, List<int> sequence) {
        int i = 0;

        foreach (var n in array) {
            if (i == sequence.Count) {
                break;
            }
            if (n == sequence[i]) {
                i++;
            }
        }

        return i == sequence.Count;
    }
}