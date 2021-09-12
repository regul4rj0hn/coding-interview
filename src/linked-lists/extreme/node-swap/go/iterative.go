package main

type LinkedList struct {
	Value int
	Next  *LinkedList
}

// O(n) time | O(1) space
// where N is the number of nodes in the Linked List
func NodeSwap(head *LinkedList) *LinkedList {
	tempNode := &LinkedList{Value: 0}
	tempNode.Next = head

	prevNode := tempNode
	for prevNode.Next != nil && prevNode.Next.Next != nil {
		firstNode := prevNode.Next
		secondNode := prevNode.Next.Next
		// prevNode -> firstNode -> secondNode -> x
		firstNode.Next = secondNode.Next
		secondNode.Next = firstNode
		prevNode.Next = secondNode
		// prevNode -> secondNode -> firstNode -> x
		prevNode = firstNode
	}
	return tempNode.Next
}
