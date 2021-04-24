using System;

/*
No improvement time or space complexity over the iterative one, just less nested IFs and cleaner code.

Time : O(n+m) - Where N is the number of nodes in the first list and M the number of nodes in the second input list
Space: (1)    - Constant space, merge in place
*/
public class Program
{
    // This is an input class. Do not edit.
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
        var p1 = headOne;
        var p2 = headTwo;
        LinkedList current = null;

        while (p1 != null && p2 != null)
        {
            if (p1.value < p2.value)
            {
                current = p1;
                p1 = p1.next;
            }
            else
            {
                if (current != null)
                {
                    current.next = p2;
                }
                current = p2;
                p2 = p2.next;
                current.next = p1;
            }
        }

        if (p1 == null)
        {
            current.next = p2;
        }

        return headOne.value < headTwo.value ? headOne : headTwo;
    }
}
