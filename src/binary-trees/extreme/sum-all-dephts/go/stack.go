package main

type BinaryTree struct {
	Value       int
	Left, Right *BinaryTree
}

// For the average case where the tree is balanced
// O(n.log(n)) time | O(h) space
// where N is the number of nodes and H the height of the Binary Tree
func AllKindsOfNodeDepths(root *BinaryTree) int {
	sumOfDepths := 0
	stack := []*BinaryTree{root}
	var node *BinaryTree
	for len(stack) > 0 {
		node, stack = stack[len(stack)-1], stack[:len(stack)-1]
		if node == nil {
			continue
		}
		sumOfDepths += nodeDepths(node, 0)
		stack = append(stack, node.Left)
		stack = append(stack, node.Right)
	}
	return sumOfDepths
}

func nodeDepths(node *BinaryTree, depth int) int {
	if node == nil {
		return 0
	}
	return depth + nodeDepths(node.Left, depth+1) + nodeDepths(node.Right, depth+1)
}
