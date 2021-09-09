package main

// Upper Bound: O((n*(2n)!)/(n!/(n+1)!)) time | O(n) space
func NumberOfBinaryTreeTopologies(n int) int {
	if n == 0 {
		return 1
	}
	treeCount := 0
	for leftTree := 0; leftTree < n; leftTree++ {
		rightTree := n - 1 - leftTree
		countLeftTree := NumberOfBinaryTreeTopologies(leftTree)
		countRightTree := NumberOfBinaryTreeTopologies(rightTree)
		treeCount += countLeftTree * countRightTree
	}
	return treeCount
}
