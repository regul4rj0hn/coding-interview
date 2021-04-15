using System.Collections.Generic;
using System;

/*
Imagine we've got a sorted stack except for the top element. In this scenario what we'd need to do is pop the top element off and compare to the next element, if it's greater continue popping off elements until we find the correct position for our original top, at which point we push all elements back into the stack as they were already sorted.

So if we now consider the full stack unsorted, the steps are the following:
 1. Pop an item from the top of the stack, and hold onto it in memory.
 2. Sort the rest of the stack. To do so, repeat step #1 until the stack is empty, at which point we've reached the base case since an empty stack is always sorted.
 3. Insert the most recently popped off item from step #1 back into the now sorted stack but in its proper sorted position following the algorithm of inserting one unsorted element in a sorted stack. The first time that we reinsert an item, it'll be inserted in an empty stack.

Time : O(n^2) - Where N is the length of the input list (stack)
Space: O(n)   - For the frames on the recursive call stack
*/
public class Program {
    public List<int> SortStack (List<int> stack) {
        if (stack.Count == 0) {
            return stack;
        }

        var top = stack[stack.Count - 1];

        stack.RemoveAt (stack.Count - 1);
        SortStack (stack);
        InsertInSortedOrder (stack, top);

        return stack;
    }

    private void InsertInSortedOrder (List<int> stack, int val) {
        if (stack.Count == 0 || stack[stack.Count - 1] <= val) {
            stack.Add (val);
            return;
        }

        var top = stack[stack.Count - 1];
        stack.RemoveAt (stack.Count - 1);
        InsertInSortedOrder (stack, val);
        stack.Add (top);
    }
}
