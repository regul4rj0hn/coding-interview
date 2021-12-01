class LinkedList {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

// O(n) time | O(1) space
function removeDuplicatesFromLinkedList(linkedList) {
    let current = linkedList
    while (current !== null) {
        let nextDistinctNode = current.next
        while (nextDistinctNode !== null && nextDistinctNode.value === current.value) {
            nextDistinctNode = nextDistinctNode.next
        }
        current.next = nextDistinctNode
        current = nextDistinctNode
    }
    return linkedList
}

exports.LinkedList = LinkedList;
exports.removeDuplicatesFromLinkedList = removeDuplicatesFromLinkedList;
