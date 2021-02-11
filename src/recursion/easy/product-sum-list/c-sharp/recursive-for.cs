using System;
using System.Collections.Generic;

/*
Time : O(n) - Where N is the *total* number of elements including special arrays
Space: O(d) - Where D is the depth of the deepest special array for the recursive call stack
*/
public class Program {
    public static int ProductSum (List<object> array) {
        return DigIn (array, 1);
    }

    private static int DigIn (List<object> list, int depth) {
        int total = 0;

        foreach (var element in list) {
            if (element is int) {
                total += (int) element;
            }
            else {
                total += DigIn ((List<object>) element, depth + 1);
            }
        }

        return total * depth;
    }
}
