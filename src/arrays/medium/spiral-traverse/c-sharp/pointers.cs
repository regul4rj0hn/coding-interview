using System;
using System.Collections.Generic;

/*
General approach is to have four pointers to keep track of where the current loop's row and column begin and end.
On each iteration we complete one full "loop" around the spiral, increasing the start pointers and shrinking the end pointers, working our way towards the center.
There's an edge case when there's a single row/column in the middle of the matrix, and we don't want to double-count the values inside it (that where caught by the previous corresponding loop). Just check if row/column start is smaller than row/column end.

Time : O(n) - Where N is the total number of elements on the two-dimensional input array
Space: O(n) - Store each element once on the output list
*/
public class Program {
    public static List<int> SpiralTraverse (int[, ] array) {
        var output = new List<int> ();
        var rowStart = 0;
        var colStart = 0;
        var rowEnd = array.GetLength (0) - 1;
        var colEnd = array.GetLength (1) - 1;

        while (rowStart <= rowEnd && colStart <= colEnd) {
            for (int i = colStart; i <= colEnd; i++) {
                output.Add (array[rowStart, i]);
            }
            rowStart++;
            for (int i = rowStart; i <= rowEnd; i++) {
                output.Add (array[i, colEnd]);
            }
            colEnd--;
            if (rowStart <= rowEnd) {
                for (int i = colEnd; i >= colStart; i--) {
                    output.Add (array[rowEnd, i]);
                }
            }
            rowEnd--;
            if (colStart <= colEnd) {
                for (int i = rowEnd; i >= rowStart; i--) {
                    output.Add (array[i, colStart]);
                }
            }
            colStart++;
        }

        return output;
    }
}