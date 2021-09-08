package main

type LinkedList struct {
	Value int
	Next  *LinkedList
}

// O(n) time | O(1) space
// where N is the number of nodes in the Linked List
func RemoveDuplicatesFromLinkedList(linkedList *LinkedList) *LinkedList {
	node := linkedList
	for node != nil {
		nextDistinct := node.Next
		for nextDistinct != nil && nextDistinct.Value == node.Value {
			nextDistinct = nextDistinct.Next
		}
		node.Next = nextDistinct
		node = nextDistinct
	}
	return linkedList
}
