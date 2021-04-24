using System;

/*
Time : O(n) - Where N is the number of nodes on the singly linked list
Space: O(1) - Reverse in place
*/
public class Program
{
    public static LinkedList ReverseLinkedList(LinkedList head)
    {
        LinkedList previous = null;
        LinkedList current = head;

        while (current != null)
        {
            var next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        return previous;
    }

    public class LinkedList
    {
        public int Value;
        public LinkedList Next = null;
        public LinkedList(int value)
        {
            this.Value = value;
        }
    }
}
