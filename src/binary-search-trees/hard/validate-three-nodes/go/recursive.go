package main

type BST struct {
	Value int
	Left  *BST
	Right *BST
}

// O(h) time | O(h) space - where H is the height of the tree
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
	if node == nil {
		return false
	}
	if node == target {
		return true
	}
	if target.Value < node.Value {
		return isDescendant(node.Left, target)
	}
	return isDescendant(node.Right, target)
}
