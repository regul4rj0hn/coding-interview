package main

type LinkedList struct {
	Value int
	Next  *LinkedList
}

// O(n) time | O(1) space
// where N is the length of the linked list
func ZipLinkedList(linkedList *LinkedList) *LinkedList {
	if linkedList.Next == nil || linkedList.Next.Next == nil {
		return linkedList
	}
	firstHalfHead := linkedList
	secondHalfHead := splitLinkedList(linkedList)

	reverseSecondHalfHead := reverseLinkedList(secondHalfHead)

	return interweaveLinkedLists(firstHalfHead, reverseSecondHalfHead)
}

func splitLinkedList(ll *LinkedList) *LinkedList {
	slowIterator := ll
	fastIterator := ll
	for fastIterator != nil && fastIterator.Next != nil {
		slowIterator = slowIterator.Next
		fastIterator = fastIterator.Next.Next
	}
	secondHalfHead := slowIterator.Next
	slowIterator.Next = nil
	return secondHalfHead
}

func interweaveLinkedLists(ll1 *LinkedList, ll2 *LinkedList) *LinkedList {
	oneIterator := ll1
	twoIterator := ll2
	for oneIterator != nil && twoIterator != nil {
		oneIteratorNext := oneIterator.Next
		twoIteratorNext := twoIterator.Next

		oneIterator.Next = twoIterator
		twoIterator.Next = oneIteratorNext

		oneIterator = oneIteratorNext
		twoIterator = twoIteratorNext
	}
	return ll1
}

func reverseLinkedList(head *LinkedList) *LinkedList {
	var previous *LinkedList
	current := head
	for current != nil {
		next := current.Next
		current.Next = previous
		previous = current
		current = next
	}
	return previous
}
