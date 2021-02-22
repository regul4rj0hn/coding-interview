using System;

/*
General approach:
- Empty arrays or with one element are monotonic
- Need to check at least 2 numbers to know if it's increasing or decreasing, if the first two numbers are equal we need to continue to look for two that are different to be able to tell the direction
- Compare the current number with the previous, taking into account the direction we were going; i.e.:
    direction > 0 means increasing sequence && compare < 0 means that the current number is smaller than the previuos => not monotonic
    direction < 0 means decreasing sequence && compare > 0 means that the current number is bigger than the previous => not monotonic

Time : O(n) - Where N is the length of the input array
Space: O(1) - We check the sequence in-place
*/
public class Program {
    public static bool IsMonotonic (int[] array) {
        if (array.Length == 0 || array.Length == 1) {
            return true;
        }

        var direction = array[1] - array[0];
        for (int i = 2; i < array.Length; i++) {
            if (direction == 0) {
                direction = array[i] - array[i - 1];
                continue;
            }
            var compare = array[i] - array[i - 1];
            if (direction > 0 && compare < 0 || direction < 0 && compare > 0) {
                return false;
            }
        }

        return true;
    }
}