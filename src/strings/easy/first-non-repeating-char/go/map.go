package main

// O(n) time | O(1) space
// where N is the length of the input string
// the space stays constant cause we will at most store 26 keys (or whatever our constant alphabet is)
func FirstNonRepeatingCharacter(str string) int {
	charFrequency := map[rune]int{}

	for _, char := range str {
		charFrequency[char] += 1
	}

	for i, char := range str {
		if charFrequency[char] == 1 {
			return i
		}
	}

	return -1
}
