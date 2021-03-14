# Breadth-First Search

## Description
You're given a `Node` class that has a `name` and an array of optional `children` nodes. When put together, nodes form an acyclic tree-like structure.

Implement the `breadthFirstSearch` method on the `Node` class, which takes in an empty array, traverses the tree using the Breadth-first Search approach (specifically navigating the tree from left to right), stores all of the nodes' names in the input array, and returns it.

If you're unfamiliar with Breadth-first Search, check [this](https://en.wikipedia.org/wiki/Breadth-first_search) out.

## Sample Input
```
graph = A
     /  |  \
    B   C   D
   / \     / \
  E   F   G   H
     / \   \
    I   J   K
```

## Sample Output
```
["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"]
```