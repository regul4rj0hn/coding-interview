using System;

/*
Since it's a singly-linked list we cannot count K backwards from the tail without first going to the end of the list. To workaround this fact, we define two pointers on the head of the list, A and B. We advance the B pointer by K nodes, so that B will be ahead of A by K nodes, which is the difference from the end that we are looking for.

Unless B is pointing at the last node of the list - which would mean we need to delete head, we advance both pointers A and B simultaneously. When B reaches the end of the list, A will now be pointing to the node that's right before our target node to remove - so distance K from the end.

To finish we just remove A.next, by pointing it to A.next.next.

Time : O(n) - Where N is the number of nodes on the input linked list
Space: O(1) - No extra space as the node is deleted in-place from the list
*/
public class Program {
    public static void RemoveKthNodeFromEnd (LinkedList head, int k) {
        var count = 1;
        var first = head;
        var second = head;

        while (count <= k) {
            count++;
            second = second.Next;
        }
        if (second == null) {
            head.Value = head.Next.Value;
            head.Next = head.Next.Next;
            return;
        }
        while (second.Next != null) {
            second = second.Next;
            first = first.Next;
        }

        first.Next = first.Next.Next;
    }

    public class LinkedList {
        public int Value;
        public LinkedList Next = null;

        public LinkedList (int value) {
            this.Value = value;
        }
    }
}
