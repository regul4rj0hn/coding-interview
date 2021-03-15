using System.Collections.Generic;
using System;

/*
This solution is potentially more efficient as with a single loop it transforms numbers in place, adds them together taking the carry from the previous sum into account, and puts the resulting number into a node of the output list.
Should potentially be faster, but to be honest I like the other solution better (way more clear).

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
        var output = new LinkedList(0);
        var currentNode = output;
        var carry = 0;

        var nodeOne = linkedListOne;
        var nodeTwo = linkedListTwo;

        while (nodeOne != null || nodeTwo != null || carry != 0)
        {
            var valueOne = nodeOne != null ? nodeOne.value : 0;
            var valueTwo = nodeTwo != null ? nodeTwo.value : 0;
            var sum = valueOne + valueTwo + carry;

            var currentValue = sum % 10;
            var node = new LinkedList(currentValue);
            currentNode.next = node;
            currentNode = node;

            carry = sum / 10;
            nodeOne = nodeOne != null ? nodeOne.next : null;
            nodeTwo = nodeTwo != null ? nodeTwo.next : null;
        }

        return output.next;
    }
}