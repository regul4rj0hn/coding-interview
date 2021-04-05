using System;
using System.Collections.Generic;

/*
First of all sort the intervals with respect to their starting values, that allows us to merge all overlapping intervals in a single traversal through the new sorted array.
Traverse the sorted array and on each iteration compare the start of the next interval to the end of the current interval to look for an overlap: 
 - If we find an overlap, then we mutate the current interval so as to merge the next interval into it.
 - Otherwise we just add the current interval as is to our output list.

When we finish traversing the sorted intervals array, our output list will contain the desired result with no overlaps to return.

Time : O(n.log(n)) - Where N is the length of the input two dimentional array, assuming O(n.log(n)) sort time complexity
Space: O(n)        - To store the sorted intervals and output array
*/
public class Program {
    public int[][] MergeOverlappingIntervals (int[][] intervals) {
        var sortedIntervals = intervals.Clone() as int[][];
        Array.Sort (sortedIntervals, (a, b) => a[0].CompareTo (b[0]));

        var output = new List<int[]>();
        var current = sortedIntervals[0];
        output.Add (current);

        foreach (var next in sortedIntervals) {
            var currentEnd = current[1];
            var nextStart = next[0];
            var nextEnd = next[1];
            
            if (currentEnd >= nextStart) {
                current[1] = Math.Max (currentEnd, nextEnd);
            }
            else {
                current = next;
                output.Add (current);
            }
        }

        return output.ToArray();
    }
}