package main

type LinkedList struct {
	Value int
	Next  *LinkedList
}

func SumOfLinkedLists(linkedListOne *LinkedList, linkedListTwo *LinkedList) *LinkedList {
	newLinkedListHead := &LinkedList{Value: 0}
	currentNode := newLinkedListHead
	carry := 0
	nodeOne := linkedListOne
	nodeTwo := linkedListTwo

	for nodeOne != nil || nodeTwo != nil || carry != 0 {
		var valueOne, valueTwo int
		if nodeOne != nil {
			valueOne = nodeOne.Value
		}
		if nodeTwo != nil {
			valueTwo = nodeTwo.Value
		}

		valueSum := valueOne + valueTwo + carry
		newValue := valueSum % 10
		newNode := &LinkedList{Value: newValue}
		currentNode.Next = newNode
		currentNode = newNode
		carry = valueSum / 10

		if nodeOne != nil {
			nodeOne = nodeOne.Next
		}
		if nodeTwo != nil {
			nodeTwo = nodeTwo.Next
		}
	}

	return newLinkedListHead.Next
}
