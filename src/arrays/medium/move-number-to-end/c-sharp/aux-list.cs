using System;
using System.Collections.Generic;

/*
This approach takes advantage of the fact that the Add() method always adds at the end and keeps the count of how many numbers equals to the target there are on the input list.
In the worst case, where the list is full of toMove items, the time complexity is 2N (pretty bad for the simple task, but does not mutate the input list).

Time : O(n) - Where N is the length of the input list
Space: O(n) - For the output list
*/
public class Program {
    public static List<int> MoveElementToEnd (List<int> array, int toMove) {
        var output = new List<int> ();
        var count = 0;

        foreach (int i in array) {
            if (i == toMove) {
                count++;
            }
            else {
                output.Add (i);
            }
        }

        AddLast (output, toMove, count);

        return output;
    }

    private static void AddLast (List<int> list, int toAdd, int count) {
        for (int i = 0; i < count; i++) {
            list.Add (toAdd);
        }
    }
}