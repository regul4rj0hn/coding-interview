package main

// This is an input class. Do not edit.
type BST struct {
	Value int
	Left  *BST
	Right *BST
}

type treeInfo struct {
	nodesVisitedCount int
	lastVisitedValue  int
}

// O(h + k) time | O(h) space
// where H is the height of the tree and K is the input parameter
func FindKthLargestValueInBst(tree *BST, k int) int {
	treeInfo := treeInfo{0, -1}
	reverseInOrderTraverse(tree, k, &treeInfo)
	return treeInfo.lastVisitedValue
}

func reverseInOrderTraverse(node *BST, k int, treeInfo *treeInfo) {
	if node == nil || treeInfo.nodesVisitedCount >= k {
		return
	}

	reverseInOrderTraverse(node.Right, k, treeInfo)
	if treeInfo.nodesVisitedCount < k {
		treeInfo.nodesVisitedCount += 1
		treeInfo.lastVisitedValue = node.Value
		reverseInOrderTraverse(node.Left, k, treeInfo)
	}
}
