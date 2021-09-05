package main

import (
	"math"
)

type BinaryTree struct {
	Value       int
	Left, Right *BinaryTree
}

// O(n) time | O(log(n)) space
func MaxPathSum(tree *BinaryTree) int {
	_, maxSum := findMaxSum(tree)
	return maxSum
}

func findMaxSum(tree *BinaryTree) (int, int) {
	if tree == nil {
		return 0, math.MinInt32
	}
	leftBranchSum, leftPathSum := findMaxSum(tree.Left)
	rightBranchSum, rightPathSum := findMaxSum(tree.Right)
	childBranchSum := max(leftBranchSum, rightBranchSum)

	value := tree.Value
	maxBranchSum := max(childBranchSum+value, value)
	maxRootNodeSum := max(leftBranchSum+value+rightBranchSum, maxBranchSum)
	maxPathSum := max(leftPathSum, rightPathSum, maxRootNodeSum)

	return maxBranchSum, maxPathSum
}

func max(first int, args ...int) int {
	for _, arg := range args {
		if arg > first {
			first = arg
		}
	}
	return first
}
