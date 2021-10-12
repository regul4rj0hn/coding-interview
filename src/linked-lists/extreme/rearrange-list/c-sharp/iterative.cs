using System;

/*
To solve the problem we can create pointers to three separate lists with the values smaller, equal and greater than K respectively.
We loop through the input list once arranging the nodes per the criteria above, without changing their original ordering.
Once that is done all we need to do is chain the three lists together, just watching out for empty lists.

To clean up the code a bit, we use a LinkedListPair object that holds a list's head and tail nodes.
*/
public class Program {
	
	// O(n) time | O(1) space - where N is the number of nodes in the LinkedList
	public static LinkedList RearrangeLinkedList(LinkedList head, int k) {
		LinkedList smallerListHead = null;
		LinkedList smallerListTail = null;
		LinkedList equalListHead = null;
		LinkedList equalListTail = null;
		LinkedList greaterListHead = null;
		LinkedList greaterListTail = null;
		
		var node = head;
		while (node != null) {
			if (node.value < k) {
				var smallerList = growLinkedList(smallerListHead, smallerListTail, node);
				smallerListHead = smallerList.head;
				smallerListTail = smallerList.tail;
			} else if (node.value > k) {
				var greaterList = growLinkedList(greaterListHead, greaterListTail, node);
				greaterListHead = greaterList.head;
				greaterListTail = greaterList.tail;
			} else {
				var equalList = growLinkedList(equalListHead, equalListTail, node);
				equalListHead = equalList.head;
				equalListTail = equalList.tail;
			}
			
			var prevNode = node;
			node = node.next;
			prevNode.next = null;
		}
		
		var firstPair = connectLinkedLists(smallerListHead, smallerListTail, equalListHead, equalListTail);
		var finalPair = connectLinkedLists(firstPair.head, firstPair.tail, greaterListHead, greaterListTail);
		return finalPair.head;
	}
	
	private static LinkedListPair growLinkedList(LinkedList head, LinkedList tail, LinkedList node) {
		var newHead = head;
		var newTail = node;
		
		if (newHead == null) {
			newHead = node;
		}
		if (tail != null) {
			tail.next = node;
		}
		return new LinkedListPair(newHead, newTail);
	}
	
	private static LinkedListPair connectLinkedLists(LinkedList headOne, LinkedList tailOne, LinkedList headTwo, LinkedList tailTwo) {
		var newHead = headOne == null ? headTwo : headOne;
		var newTail = tailTwo == null ? tailOne : tailTwo;
		
		if (tailOne != null) {
			tailOne.next = headTwo;
		}
		return new LinkedListPair(newHead, newTail);
	}
	
	private class LinkedListPair {
		public LinkedList head;
		public LinkedList tail;
		
		public LinkedListPair(LinkedList h, LinkedList t) {
			head = h;
			tail = t;
		}
	}

	public class LinkedList {
		public int value;
		public LinkedList next;

		public LinkedList(int value) {
			this.value = value;
			next = null;
		}
	}
}
