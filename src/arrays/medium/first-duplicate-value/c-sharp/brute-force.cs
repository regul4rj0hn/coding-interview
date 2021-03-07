using System;

/*
For each index in the input array, traverse the array again looking for a duplicate for the current element (we don't care if there's more than one, so we break there).
When duplicates are found, compare the index with the current duplicate, with the last duplicate that was found, and take the smaller.
If no duplicates are found minSecondIndex will be set to an invalid index, so just return -1, otherwise return array[minSecondIndex]

Time : O(n^2) - Where N is the length of the input array, two nested loops
Space: O(1)   - We check the sequence in-place
*/
public class Program {
    public int FirstDuplicateValue (int[] array) {
        var minSecondIndex = array.Length;

        for (int i = 0; i < array.Length; i++) {
            var current = array[i];

            for (int j = i + 1; j < array.Length; j++) {
                var compare = array[j];
                if (current == compare) {
                    minSecondIndex = Math.Min (minSecondIndex, j);
                    break;
                }
            }
        }

        return minSecondIndex == array.Length ? -1 : array[minSecondIndex];
    }
}