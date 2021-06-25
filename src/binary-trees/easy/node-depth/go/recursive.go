package main

type BinaryTree struct {
	Value       int
	Left, Right *BinaryTree
}

func NodeDepths(root *BinaryTree) int {
	return nodeDepths(root, 0)
}

func nodeDepths(root *BinaryTree, depth int) int {
	if root == nil {
		return 0
	}
	return depth + nodeDepths(root.Left, depth+1) + nodeDepths(root.Right, depth+1)
}
