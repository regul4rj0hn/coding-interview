package main

import (
	"math"
)

// O(n^2) time | O(d) space
// where N is the number of nodes on each array and D is the depht of the BST
func SameBsts(arrayOne, arrayTwo []int) bool {
	return sameBsts(arrayOne, arrayTwo, 0, 0, math.MinInt32, math.MaxInt32)
}

func sameBsts(arrayOne, arrayTwo []int, rootOne, rootTwo int, min, max int) bool {
	if rootOne == -1 || rootTwo == -1 {
		return rootOne == rootTwo
	}
	if arrayOne[rootOne] != arrayTwo[rootTwo] {
		return false
	}

	leftRootOne := getFirstSmallerIndex(arrayOne, rootOne, min)
	leftRootTwo := getFirstSmallerIndex(arrayTwo, rootTwo, min)
	rightRootOne := getFirstBiggerOrEqualIndex(arrayOne, rootOne, max)
	rightRootTwo := getFirstBiggerOrEqualIndex(arrayTwo, rootTwo, max)

	current := arrayOne[rootOne]
	leftSame := sameBsts(arrayOne, arrayTwo, leftRootOne, leftRootTwo, min, current)
	rightSame := sameBsts(arrayOne, arrayTwo, rightRootOne, rightRootTwo, current, max)

	return leftSame && rightSame
}

// Find the index of the first smaller value after the start index.
// Make sure that this value is greater than or equal to the min value,
// which is the value of the previous parent node in the BST. If it isn't
// then that value is located in the left subtree of the previous parent.
func getFirstSmallerIndex(array []int, start, min int) int {
	for i := start + 1; i < len(array); i++ {
		if array[i] < array[start] && array[i] >= min {
			return i
		}
	}
	return -1
}

// Find the index of the first bigger or equal value after the start index.
// Make sure that this value is smaller than the maxmum value,
// which is the value of the previous parent node in the BST. If it isn't
// then that value is located in the right subtree of the previous parent.
func getFirstBiggerOrEqualIndex(array []int, start, max int) int {
	for i := start + 1; i < len(array); i++ {
		if array[i] >= array[start] && array[i] < max {
			return i
		}
	}
	return -1
}
