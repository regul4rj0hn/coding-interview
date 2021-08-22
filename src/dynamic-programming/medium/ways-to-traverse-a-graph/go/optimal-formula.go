package main

// O(n + m) time | O(1) space
// The number of permutations of right and down movements is the number of ways to traverse
// We could also store the possible factorial solutions like on the C# implementation to make it O(1) instead of lineal
func NumberOfWaysToTraverseGraph(width int, height int) int {
	xDistance := width - 1
	yDistance := height - 1

	numerator := factorial(xDistance + yDistance)
	denominator := factorial(xDistance) * factorial(yDistance)
	return numerator / denominator
}

func factorial(num int) int {
	result := 1
	for n := 2; n < num+1; n++ {
		result *= n
	}
	return result
}
