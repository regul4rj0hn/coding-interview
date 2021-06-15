package main

// O(n + m) time | O(c) space
// where N is the number of chars, M is the length of the document, and C is the number of unique chars in the N string
func GenerateDocument(characters string, document string) bool {
	charCount := map[rune]int{}

	for _, char := range characters {
		charCount[char] = charCount[char] + 1
	}

	for _, char := range document {
		if charCount[char] == 0 {
			return false
		}
		charCount[char] = charCount[char] - 1
	}

	return true
}
