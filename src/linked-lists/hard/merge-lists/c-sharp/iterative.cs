using System;

/*
Time : O(n+m) - Where N is the number of nodes in the first list and M the number of nodes in the second input list
Space: (1)    - Constant space, merge in place
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
        LinkedList newHead = null;
        if (headOne.value <= headTwo.value)
        {
            newHead = headOne;
            headOne = headOne.next;
        }
        else
        {
            newHead = headTwo;
            headTwo = headTwo.next;
        }

        var current = newHead;

        while (headOne != null || headTwo != null)
        {
            if (headOne != null && headTwo != null)
            {
                if (headOne.value <= headTwo.value)
                {
                    current.next = headOne;
                    headOne = headOne.next;
                }
                else
                {
                    current.next = headTwo;
                    headTwo = headTwo.next;
                }
            }
            else
            {
                if (headTwo != null)
                {
                    current.next = headTwo;
                    headTwo = headTwo.next;
                }
                else
                {
                    current.next = headOne;
                    headOne = headOne.next;
                }
            }
            current = current.next;
        }

        return newHead;
    }
}
