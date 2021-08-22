package main

// O(2^(n + m)) time | O(n + m) space
// where N is the width and M is the height of the graph
func NumberOfWaysToTraverseGraph(width int, height int) int {
	if width == 1 || height == 1 {
		return 1
	}
	return NumberOfWaysToTraverseGraph(width-1, height) + NumberOfWaysToTraverseGraph(width, height-1)
}
