using System.Collections.Generic;
using System;

/*
The approach is to transform the two linked lists into integer values, add them together, and then transform the sum into a linked list.
The code is a lot cleaner than the single-loop solution, but it might be a bit slower despite of the time and space complexity analysis being the same.

Time : O(max(n+m)) - Where N and M are the number of nodes on the input one and two linked list respectively
Space: O(max(n+m)) - To store the output list with the sum
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

    public LinkedList SumOfLinkedLists(LinkedList linkedListOne, LinkedList linkedListTwo)
    {
        var valueOne = LinkedListToInt(linkedListOne);
        var valueTwo = LinkedListToInt(linkedListTwo);

        return IntegerToLinkedList(valueOne + valueTwo);
    }

    private int LinkedListToInt(LinkedList list)
    {
        var output = 0;
        var mult = 1;
        var currentNode = list;

        while (currentNode != null)
        {
            output += currentNode.value * mult;
            mult *= 10;
            currentNode = currentNode.next;
        }

        return output;
    }

    private LinkedList IntegerToLinkedList(int num)
    {
        var output = new LinkedList(num % 10);
        var currentNode = output;

        while (num / 10 != 0)
        {
            num /= 10;
            currentNode.next = new LinkedList(num % 10);
            currentNode = currentNode.next;
        }

        return output;
    }
}