using System;

/*
The straight forward way to solve the problem is to keep an array of visited nodes initialized in false, and set target jump postions to true as we loop through the input array. If we jump to a position that's already set to visited true, then the graph doesn't form a single cycle. This of course implies O(n) space complexity for storing the "visited" nodes array.

The optimal space solution though, is to count the visited elements, keeping in mind that in order for the input to form a single cycle, we need to visit _exactly_ all elements, and at the last element (N+1) that we visit we need to land back where we've started checking.

Time : O(n) - Where N is the length of the input array
Space: O(1) - No extra data structures
*/
public class Program {
    public static bool IsSingleCycle (int[] array) {
        var visited = 0;
        var index = 0;

        while (visited < array.Length) {
            if (visited > 0 && index == 0) {
                return false;
            }
            visited++;
            index = GetNextWithinBounds (index, array);
        }

        return index == 0;
    }

    private static int GetNextWithinBounds (int index, int[] array) {
        int jump = array[index];
        int next = (index + jump) % array.Length;
        return next >= 0 ? next : next + array.Length;
    }
}