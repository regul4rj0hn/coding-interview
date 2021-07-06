package main

// O(n+m) time | O(m) space
// where N is the length of the string and M the length of the sub-string inputs
func KnuthMorrisPrattAlgorithm(str, substr string) bool {
	pattern := buildPattern(substr)
	return doesMatch(str, substr, pattern)
}

func buildPattern(substr string) []int {
	pattern := make([]int, len(substr))
	for i := range substr {
		pattern[i] = -1
	}
	i, j := 1, 0
	for i < len(substr) {
		if substr[i] == substr[j] {
			pattern[i] = j
			i, j = i+1, j+1
			continue
		}
		if j > 0 {
			j = pattern[j-1] + 1
		}
		i += 1
	}
	return pattern
}

func doesMatch(str, substr string, pattern []int) bool {
	i, j := 0, 0
	for i+len(substr)-j <= len(str) {
		if str[i] == substr[j] {
			if j == len(substr)-1 {
				return true
			}
			i, j = i+1, j+1
			continue
		}
		if j > 0 {
			j = pattern[j-1] + 1
			continue
		}
		i += 1
	}
	return false
}
