using System;

/*
Time : O(n) - Cycle through N nodes in the list once
Space: O(1) - Editing the list in-place
*/
public class Program {
    public class LinkedList {
        public int value;
        public LinkedList next;

        public LinkedList (int value) {
            this.value = value;
            this.next = null;
        }
    }

    public LinkedList RemoveDuplicatesFromLinkedList (LinkedList linkedList) {
        LinkedList currentNode = linkedList;
        LinkedList nextNode = linkedList.next;

        while (nextNode != null) {
            if (nextNode.value == currentNode.value) {
                currentNode.next = nextNode.next;
            }
            else {
                currentNode = nextNode;
            }
            nextNode = currentNode.next;
        }

        return linkedList;
    }
}