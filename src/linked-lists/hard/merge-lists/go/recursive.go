package main

type LinkedList struct {
	Value int
	Next  *LinkedList
}

// O(n + m) time | O(n + m) space
// where N and M are the number of nodes in the first and second Linked Lists respectively
func MergeLinkedLists(headOne *LinkedList, headTwo *LinkedList) *LinkedList {
	recursiveMergeLists(headOne, headTwo, nil)
	if headOne.Value < headTwo.Value {
		return headOne
	}
	return headTwo
}

func recursiveMergeLists(p1, p2, p1Prev *LinkedList) {
	if p1 == nil {
		p1Prev.Next = p2
		return
	}
	if p2 == nil {
		return
	}
	if p1.Value < p2.Value {
		recursiveMergeLists(p1.Next, p2, p1)
		return
	}
	if p1Prev != nil {
		p1Prev.Next = p2
	}
	newP2 := p2.Next
	p2.Next = p1
	recursiveMergeLists(p1, newP2, p2)
}
