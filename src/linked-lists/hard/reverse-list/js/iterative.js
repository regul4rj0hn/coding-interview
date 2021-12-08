class LinkedList {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

// O(n) time | O(1) space
function reverseLinkedList(head) {
let previousNode = null
    let currentNode = head
    while (currentNode !== null) {
        const nextNode = currentNode.next
        currentNode.next = previousNode
        previousNode = currentNode
        currentNode = nextNode
    }
    return previousNode
}

exports.LinkedList = LinkedList;
exports.reverseLinkedList = reverseLinkedList;
