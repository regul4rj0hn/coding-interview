using System;
using System.Collections.Generic;

/**
    Time: O(n) - Has to run through the whole list once
    Space: O(1) - No extra storage
**/
public class Program {
    public static bool IsValidSubsequence (List<int> array, List<int> sequence) {
        int i = 0, j = 0;

        while (i < array.Count && j < sequence.Count) {
            if (array[i] == sequence[j]) {
                j++;
            }
            i++;
        }

        return j == sequence.Count;
    }
}