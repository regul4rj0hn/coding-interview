package main

type BST struct {
	Value int
	Left  *BST
	Right *BST
}

// O(h) time | O(1) space - where H is the height of the tree
func ValidateThreeNodes(nodeOne *BST, nodeTwo *BST, nodeThree *BST) bool {
	if isDescendant(nodeTwo, nodeOne) {
		return isDescendant(nodeThree, nodeTwo)
	}
	if isDescendant(nodeTwo, nodeThree) {
		return isDescendant(nodeOne, nodeTwo)
	}
	return false
}

func isDescendant(node *BST, target *BST) bool {
	current := node
	for current != nil && current != target {
		if target.Value < current.Value {
			current = current.Left
		} else {
			current = current.Right
		}
	}
	return current == target
}
