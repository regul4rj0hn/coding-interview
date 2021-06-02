package main

type BinaryTree struct {
	Value int
	Left  *BinaryTree
	Right *BinaryTree
}

type TreeInfo struct {
	diameter int
	height   int
}

// Average case when the tree is balanced:
// O(n) time | O(h) space
// Where N is the number of nodes and H is the height of the Binary Tree
func BinaryTreeDiameter(tree *BinaryTree) int {
	return getTreeInfo(tree).diameter
}

func getTreeInfo(tree *BinaryTree) TreeInfo {
	if tree == nil {
		return TreeInfo{0, 0}
	}

	leftTreeInfo := getTreeInfo(tree.Left)
	rightTreeInfo := getTreeInfo(tree.Right)

	longestPathThroughRoot := leftTreeInfo.height + rightTreeInfo.height
	maxDiameter := max(leftTreeInfo.diameter, rightTreeInfo.diameter)
	currentDiameter := max(longestPathThroughRoot, maxDiameter)
	currentHeight := 1 + max(leftTreeInfo.height, rightTreeInfo.height)

	return TreeInfo{currentDiameter, currentHeight}
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
