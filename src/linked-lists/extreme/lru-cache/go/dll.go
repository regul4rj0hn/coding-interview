package main

type DoublyLinkedListNode struct {
	key   string
	value int
	prev  *DoublyLinkedListNode
	next  *DoublyLinkedListNode
}

type DoublyLinkedList struct {
	head *DoublyLinkedListNode
	tail *DoublyLinkedListNode
}

// DLL Methods
func (list *DoublyLinkedList) setHead(node *DoublyLinkedListNode) {
	if list.head == node {
		return
	}
	if list.head == nil {
		list.head, list.tail = node, node
		return
	}
	if list.head == list.tail {
		list.tail.prev = node
		list.head = node
		list.head.next = list.tail
		return
	}
	if list.tail == node {
		list.removeTail()
	}
	node.removeBindings()
	list.head.prev = node
	node.next = list.head
	list.head = node
}

func (list *DoublyLinkedList) removeTail() {
	if list.tail == nil {
		return
	}
	if list.tail == list.head {
		list.head, list.tail = nil, nil
		return
	}
	list.tail = list.tail.prev
	list.tail.next = nil
}

func (node *DoublyLinkedListNode) removeBindings() {
	if node.prev != nil {
		node.prev.next = node.next
	}
	if node.next != nil {
		node.next.prev = node.prev
	}
	node.prev, node.next = nil, nil
}
