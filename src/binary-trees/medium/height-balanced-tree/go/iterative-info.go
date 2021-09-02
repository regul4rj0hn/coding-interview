package main

// This is an input class. Do not edit.
type BinaryTree struct {
	Value int
	Left  *BinaryTree
	Right *BinaryTree
}

type treeInfo struct {
	isBalanced bool
	height     int
}

// O(n) time | O(h) space - where N is the number of nodes in the binary tree
func HeightBalancedBinaryTree(tree *BinaryTree) bool {
	treeInfo := getTreeInfo(tree)
	return treeInfo.isBalanced
}

func getTreeInfo(node *BinaryTree) treeInfo {
	if node == nil {
		return treeInfo{isBalanced: true, height: -1}
	}
	left := getTreeInfo(node.Left)
	right := getTreeInfo(node.Right)
	isBalanced := left.isBalanced && right.isBalanced && abs(left.height-right.height) <= 1
	height := max(left.height, right.height) + 1

	return treeInfo{
		isBalanced: isBalanced,
		height:     height,
	}
}

func abs(a int) int {
	if a < 0 {
		return -a
	}
	return a
}

func max(a, b int) int {
	if a < b {
		return b
	}
	return a
}
