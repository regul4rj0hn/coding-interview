using System;
using System.Collections.Generic;

/*
Defines two pointers and if the current number is a target, just swaps it with the one at the end of the list, move the right counter, and analyze the left spot again. When the current number is not a target, move the left pointer to the right, until we cross the right pointer.

Time : O(n) - Where N is the length of the input list
Space: O(1) - Swap in place
*/
public class Program {
    public static List<int> MoveElementToEnd (List<int> array, int toMove) {
        int left = 0;
        int right = array.Count - 1;

        while (left < right) {
            if (array[left] == toMove) {
                array[left] = array[right];
                array[right] = toMove;
                right--;
            }
            else {
                left++;
            }
        }

        return array;
    }
}