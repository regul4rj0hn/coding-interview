package main

import (
	"math"
)

type BST struct {
	Value int
	Left  *BST
	Right *BST
}

type treeInfo struct {
	rootIndex int
}

// O(n) time | O(n) space
// where N is the length of the input array
func ReconstructBst(preOrderTraversalValues []int) *BST {
	treeInfo := &treeInfo{rootIndex: 0}
	return reconstructBstFromRange(
		math.MinInt32,
		math.MaxInt32,
		preOrderTraversalValues,
		treeInfo,
	)
}

func reconstructBstFromRange(lowerBound, upperBound int, preOrderTraversalValues []int, subtreeInfo *treeInfo) *BST {
	if subtreeInfo.rootIndex == len(preOrderTraversalValues) {
		return nil
	}

	rootValue := preOrderTraversalValues[subtreeInfo.rootIndex]
	if rootValue < lowerBound || rootValue >= upperBound {
		return nil
	}

	subtreeInfo.rootIndex += 1
	leftSubtree := reconstructBstFromRange(
		lowerBound,
		rootValue,
		preOrderTraversalValues,
		subtreeInfo,
	)
	rightSubtree := reconstructBstFromRange(
		rootValue,
		upperBound,
		preOrderTraversalValues,
		subtreeInfo,
	)
	return &BST{Value: rootValue, Left: leftSubtree, Right: rightSubtree}
}
