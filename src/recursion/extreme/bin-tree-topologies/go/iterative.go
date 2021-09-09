package main

// O(n^2) time | O(n) space
func NumberOfBinaryTreeTopologies(n int) int {
	cache := []int{1}
	for m := 1; m < n+1; m++ {
		treeCount := 0
		for leftTree := 0; leftTree < m; leftTree++ {
			rightTree := m - 1 - leftTree
			countLeftTree := cache[leftTree]
			countRightTree := cache[rightTree]
			treeCount += countLeftTree * countRightTree
		}
		cache = append(cache, treeCount)
	}

	return cache[n]
}
