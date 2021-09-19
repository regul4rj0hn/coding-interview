package main

// O(n) time | O(1) space - where N is the length of the input string
func LongestBalancedSubstring(str string) int {
	return max(
		getLongestBalancedInDirection(str, true),
		getLongestBalancedInDirection(str, false),
	)
}

func getLongestBalancedInDirection(str string, leftToRight bool) int {
	openingParens := '('
	startIdx := 0
	step := 1
	if !leftToRight {
		openingParens = ')'
		startIdx = len(str) - 1
		step = -1
	}
	maxLength := 0
	openingCount := 0
	closingCount := 0

	idx := startIdx
	for idx >= 0 && idx < len(str) {
		char := str[idx]
		if rune(char) == openingParens {
			openingCount++
		} else {
			closingCount++
		}

		if openingCount == closingCount {
			maxLength = max(maxLength, closingCount*2)
		} else if closingCount > openingCount {
			openingCount = 0
			closingCount = 0
		}
		idx += step
	}
	return maxLength
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
