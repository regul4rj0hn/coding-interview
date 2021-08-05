package main

type LinkedList struct {
	Value int
	Next  *LinkedList
}

// O(n) time | O(1) space
// where N is the number of nodes in the Linked List
func LinkedListPalindrome(head *LinkedList) bool {
	slowNode, fastNode := head, head
	for fastNode != nil && fastNode.Next != nil {
		slowNode = slowNode.Next
		fastNode = fastNode.Next.Next
	}

	reverseSecondHalfNode := reverseLinkedList(slowNode)
	firstHalfNode := head

	for reverseSecondHalfNode != nil {
		if reverseSecondHalfNode.Value != firstHalfNode.Value {
			return false
		}
		reverseSecondHalfNode = reverseSecondHalfNode.Next
		firstHalfNode = firstHalfNode.Next
	}

	return true
}

func reverseLinkedList(head *LinkedList) *LinkedList {
	var previousNode *LinkedList = nil
	var currentNode = head
	for currentNode != nil {
		nextNode := currentNode.Next
		currentNode.Next = previousNode
		previousNode = currentNode
		currentNode = nextNode
	}
	return previousNode
}
