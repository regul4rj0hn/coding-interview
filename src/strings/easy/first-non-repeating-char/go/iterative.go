package main

// O(n^2) time | O(1) space
// where N is the length of the input string
func FirstNonRepeatingCharacter(str string) int {
	for i := range str {
		var foundDuplicate = false
		for j := range str {
			if str[i] == str[j] && i != j {
				foundDuplicate = true
			}
		}
		if !foundDuplicate {
			return i
		}
	}
	return -1
}
