class LinkedList {
    constructor(value) {
      this.value = value;
      this.next = null;
    }
}

// O(max(n, m)) time | O(max(n, m)) space
// where N is the length of the first LinkedList and M the lenght of the second
function sumOfLinkedLists(linkedListOne, linkedListTwo) {
    const newHead = new LinkedList(0)
    let currentNode = newHead
    let carry = 0

    let nodeOne = linkedListOne
    let nodeTwo = linkedListTwo
    while (nodeOne !== null || nodeTwo !== null || carry !== 0) {
        const valueOne = nodeOne !== null ? nodeOne.value : 0
        const valueTwo = nodeTwo !== null ? nodeTwo.value : 0
        const sum = valueOne + valueTwo + carry

        const newValue = sum % 10
        const newNode = new LinkedList(newValue)
        currentNode.next = newNode
        currentNode = newNode

        carry = Math.floor(sum / 10)
        nodeOne = nodeOne !== null ? nodeOne.next : null
        nodeTwo = nodeTwo !== null ? nodeTwo.next : null
    }
    return newHead.next
}

exports.LinkedList = LinkedList;
exports.sumOfLinkedLists = sumOfLinkedLists;
