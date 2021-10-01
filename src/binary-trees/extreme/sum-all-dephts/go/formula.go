package main

type BinaryTree struct {
	Value       int
	Left, Right *BinaryTree
}

// O(n) time | O(h) space
// where N is the number of nodes and H the height of the Binary Tree
func AllKindsOfNodeDepths(root *BinaryTree) int {
	return nodeDepths(root, 0)
}

func nodeDepths(root *BinaryTree, depth int) int {
	if root == nil {
		return 0
	}
	depthSum := (depth * (depth + 1)) / 2
	return depthSum + nodeDepths(root.Left, depth+1) + nodeDepths(root.Right, depth+1)
}
