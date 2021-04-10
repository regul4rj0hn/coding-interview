using System;

/*
One possible easy solution is just using a hash table to store a pointer to every single node we've seen as we traverse the list, and return as soon as we find one that's already on our table.

The challenge with this problem comes when trying to optimize the space complexity. For this we use a simple strategy with Linked List problems: having two pointers one ahead of the other. One pointer moves one node at time, the second one skips one. Given the fact that there is a guaranteed loop in the list (per the problem definition), at some point our second pointer will reach the first one, and both will coincide in the same node.
From the point where the two pointers collide we know that:
 - First Pointer : Traveled a distance of X nodes : D + P (D nodes from the beginning of the list to the beginning of the loop, and P nodes from D to the point where nodes collided)
 - Second Pointer: Traveled a distance of 2X nodes: 2D + 2P (just double what the first pointer has traveled)
 - Reminder: What's left to travel from the point the nodes collide: R = Total - D - P  (also marks the beginning of our loop)
 - Total length of the list is: Total + P = 2D + 2P : Total = 2D + P (using the second pointer, we know it has traveled the whole list, plus the distance P, where the nodes had collided)

By making substitutions in the formulas above we can realize that the reminder distance from the node where nodes collieded to where our loop started is: R = 2D + P - P - D. That's equal to the number of nodes from the beginning of the list to the point where nodes collide (drawing it out helps).

All we need to do now is return our first pointer to the head of the list, and start advancing our second pointer one-by-one instead of skipping. The pointers will collide again, this time at the loop-starting node.

Time : O(n) - Where N is the number of nodes in the singly linked list.
Space: O(1) - No extra space used just two pointers
*/
public class Program
{
    public static LinkedList FindLoop (LinkedList head)
    {
        var first = head.next;
        var second = head.next.next;

        while (first != second)
        {
            first = first.next;
            second = second.next.next;
        }

        first = head;
        while (first != second)
        {
            first = first.next;
            second = second.next;
        }

        return first;
    }

    public class LinkedList
    {
        public int value;
        public LinkedList next = null;

        public LinkedList(int value)
        {
            this.value = value;
        }
    }
}
