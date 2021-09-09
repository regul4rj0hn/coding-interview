package main

// Upper Bound: O(n^2) time | O(n) space
func NumberOfBinaryTreeTopologies(n int) int {
	return TreeCountHelper(n, map[int]int{0: 1})
}

func TreeCountHelper(n int, cache map[int]int) int {
	if val, found := cache[n]; found {
		return val
	}
	treeCount := 0
	for leftTree := 0; leftTree < n; leftTree++ {
		rightTree := n - 1 - leftTree
		countLeftTree := NumberOfBinaryTreeTopologies(leftTree)
		countRightTree := NumberOfBinaryTreeTopologies(rightTree)
		treeCount += countLeftTree * countRightTree
	}
	cache[n] = treeCount
	return treeCount
}
