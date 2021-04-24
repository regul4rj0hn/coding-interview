using System;

/*
Just a recurisve approach, with worse space complexity than the iterative one.

Time : O(n+m) - Where N is the number of nodes in the first list and M the number of nodes in the second input list
Space: (n+m)  - For the recursive call stack frames
*/
public class Program
{
    public class LinkedList
    {
        public int value;
        public LinkedList next;

        public LinkedList(int value)
        {
            this.value = value;
            this.next = null;
        }
    }

    public static LinkedList mergeLinkedLists(LinkedList headOne, LinkedList headTwo)
    {
        RecursiveMergeLists(headOne, headTwo, null);
        return headOne.value < headTwo.value ? headOne : headTwo;
    }

    private static void RecursiveMergeLists(LinkedList l1, LinkedList l2, LinkedList current)
    {
        if (l1 == null)
        {
            current.next = l2;
            return;
        }
        if (l2 == null)
        {
            return;
        }

        if (l1.value < l2.value)
        {
            RecursiveMergeLists(l1.next, l2, l1);
        }
        else
        {
            if (current != null)
            {
                current.next = l2;
            }
            var newL2 = l2.next;
            l2.next = l1;
            RecursiveMergeLists(l1, newL2, l2);
        }
    }
}
