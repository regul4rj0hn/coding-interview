package main

type LinkedList struct {
	Value int
	Next  *LinkedList
}

// O(n) time | O(1) space
// where N is the number of nodes in the Linked List
func ShiftLinkedList(head *LinkedList, k int) *LinkedList {
	length := 1
	tail := head
	for tail.Next != nil {
		tail = tail.Next
		length += 1
	}

	offset := abs(k) % length
	if offset == 0 {
		return head
	}

	newTailPos := length - offset
	if k <= 0 {
		newTailPos = offset
	}

	newTail := head
	for i := 1; i < newTailPos; i++ {
		newTail = newTail.Next
	}

	newHead := newTail.Next
	newTail.Next = nil
	tail.Next = head
	return newHead
}

func abs(k int) int {
	if k > 0 {
		return k
	}
	return -k
}
