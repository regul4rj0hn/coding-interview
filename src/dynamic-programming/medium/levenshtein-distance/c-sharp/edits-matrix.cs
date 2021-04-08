using System;

/*
The way to approach the solution is to build a two dimensional array containing where the rows are each of the letters of one string, the columns represent each of the letters of our second string, and in each cell/interception we store the minimum number of operations that have to be performed on a substring of our target (at that index). We start building the matrix out with the empty string, which helps us account for when we need to remove a letter. E.g.:

   | "" | y | a | b | d |
-------------------------
"" |  0 | 1 | 2 | 3 | 4 |
 a |  1 | 1 | 1 | 2 | 3 |
 b |  2 | 2 | 2 | 1 | 2 |
 c |  3 | 3 | 3 | 2 | 2 |

By building the matrix we realize that the minimum number of operations at our next index i will be given by 1 + the minimum number of operations between its neighbors (to the left, above, and left-above diagonal) if the letters that we are comparing are different, or the neighboring cells _without_ the current letter (so only left-above diagonal without adding 1), if they are equal.

The answer of the minimum number of edits requiered will be stored in the right-most bottom cell.

Time : O(n.m) - Where N is the length of the str1 input and M is the length of str2 input string
Space: O(n,m) - For the NxM matrix to store the edits
*/
public class Program {
    public static int LevenshteinDistance (string str1, string str2) {
        var edits = new int[str2.Length + 1, str1.Length + 1];

        for (var i = 0; i < str2.Length + 1; i++) {
            for(var j = 0; j < str1.Length + 1; j++) {
                edits[i, j] = j;
            }
            edits[i, 0] = i;
        }

        for (var i = 1; i < str2.Length + 1; i++) {
            for (var j = 1; j < str1.Length + 1; j++) {
                if (str2[i - 1] == str1[j - 1]) {
                    edits[i, j] = edits[i - 1, j - 1];
                }
                else {
                    edits[i, j] = 1 + Math.Min (edits[i - 1, j - 1], Math.Min (edits[i - 1, j], edits[i, j - 1]));
                }
            }
        }

        return edits[str2.Length, str1.Length];
    }
}
