package main

// O(n^3) time | O(n) space - where N is the length of the input string
func LongestBalancedSubstring(str string) int {
	maxLength := 0
	for i := range str {
		for j := i + 2; j < len(str)+1; j++ {
			if isBalanced(str[i:j]) {
				currentLength := j - i
				maxLength = max(maxLength, currentLength)
			}
		}
	}
	return maxLength
}

func isBalanced(str string) bool {
	openParensStack := []rune{}
	for _, char := range str {
		if char == '(' {
			openParensStack = append(openParensStack, char)
		} else if len(openParensStack) > 0 {
			openParensStack = openParensStack[:len(openParensStack)-1]
		} else {
			return false
		}
	}
	return len(openParensStack) == 0
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
