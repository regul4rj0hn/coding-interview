using System;

/*
Since all the values inside the array are between 1 and N where N is the length of the array, we can take advantage of this fact and map each element to an specific index minus 1 (so that we don't go out of bounds).
So for e.g., for the value 2 we substract 2 - 1 = 1 and make the number in array[1] negative (-1), so that the next time we find a two, if we perform this operation and the number at position array[1] is already negative, we've found our duplicate to return.
If we finish traversing the array we just return -1.

Time : O(n) - Where N is the length of the input array
Space: O(1) - We check the sequence in-place
*/
public class Program {
    public int FirstDuplicateValue (int[] array) {
        foreach (var i in array) {
            var absValue = Math.Abs (i);
            if (array[absValue - 1] < 0) {
                return absValue;
            }
            array[absValue - 1] *= -1;
        }
        return -1;
    }
}