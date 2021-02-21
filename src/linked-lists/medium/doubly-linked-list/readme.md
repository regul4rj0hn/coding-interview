# Doubly Linked List

## Description
Write a `DoublyLinkedList` class that has a `head` and a `tail`, both of which point to either a linked list `Node` or `None` / `null`. The class should support:
- Setting the head and tail of the linked list.
- Inserting nodes before and after other nodes as well as at given positions (the position of the head node is `1`).
- Removing given nodes and removing nodes with given values.
- Searching for nodes with given values.

Note that the `setHead`, `setTail`, `insertBefore`, `insertAfter`, `insertAtPosition`, and `remove` methods all take in actual `Nodes` as input parameters, not integers! (except for `insertAtPosition`, which also takes in an integer but it represents a position); this means that you don't need to create any new `Nodes` in these methods. 

The input nodes can be either stand-alone nodes or nodes that are already in the linked list. If they're nodes that are already in the linked list, the methods will effectively be *moving* the nodes within the linked list. You won't be told if the input nodes are already in the linked list, so your code will have to defensively handle this scenario.

Each `Node` has an integer `value` as well as a `prev` node and a `next` node, both of which can point to either another node or `None` / `null`.

## Sample Usage</h3>
```
// Assume the following linked list has already been created:
1 <-> 2 <-> 3 <-> 4 <-> 5
// Assume that we also have the following stand-alone nodes:
3, 3, 6

// set the existing node with value 4 as the head
setHead(4): 4 <-> 1 <-> 2 <-> 3 <-> 5 
// set the stand-alone node with value 6 as the tail
setTail(6): 4 <-> 1 <-> 2 <-> 3 <-> 5 <-> 6 
// move the existing node with value 3 before the existing node with value 6
insertBefore(6, 3): 4 <-> 1 <-> 2 <-> 5 <-> 3 <-> 6 
// insert a stand-alone node with value 3 after the existing node with value 6
insertAfter(6, 3): 4 <-> 1 <-> 2 <-> 5 <-> 3 <-> 6 <-> 3 
// insert a stand-alone node with value 3 in position 1
insertAtPosition(1, 3): 3 <-> 4 <-> 1 <-> 2 <-> 5 <-> 3 <-> 6 <-> 3 
// remove all nodes with value 3
removeNodesWithValue(3): 4 <-> 1 <-> 2 <-> 5 <-> 6 
// remove the existing node with value 2
remove(2): 4 <-> 1 <-> 5 <-> 6 
// check if a node with value 5 is on the list
containsNodeWithValue(5): true
```
