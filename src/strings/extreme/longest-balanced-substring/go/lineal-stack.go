package main

// O(n) time | O(n) space - where N is the length of the input string
func LongestBalancedSubstring(str string) int {
	maxLength := 0
	idxStack := []int{-1}
	for i := range str {
		if str[i] == '(' {
			idxStack = append(idxStack, i)
		} else {
			idxStack = idxStack[:len(idxStack)-1]
			if len(idxStack) == 0 {
				idxStack = append(idxStack, i)
			} else {
				balancedSubstringStartIdx := idxStack[len(idxStack)-1]
				currentLength := i - balancedSubstringStartIdx
				maxLength = max(maxLength, currentLength)
			}
		}
	}
	return maxLength
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
