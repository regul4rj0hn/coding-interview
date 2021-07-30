package main

// O(n.l) time | O(c) space
// where N is the number of words, L is the length of the longest word, and C is the number of unique chars for all words
func MinimumCharactersForWords(words []string) []string {
	maxCharFrequencies := map[rune]int{}

	for _, word := range words {
		charFrequencies := countCharFrequencies(word)
		updateMaxFrequencies(charFrequencies, maxCharFrequencies)
	}

	return newArrayFromCharFrequencies(maxCharFrequencies)
}

func countCharFrequencies(str string) map[rune]int {
	charFrequencies := map[rune]int{}
	for _, char := range str {
		charFrequencies[char] += 1
	}
	return charFrequencies
}

func updateMaxFrequencies(frequencies map[rune]int, maxFrequencies map[rune]int) {
	for char, freq := range frequencies {
		if maxFrequency, found := maxFrequencies[char]; found {
			maxFrequencies[char] = max(freq, maxFrequency)
		} else {
			maxFrequencies[char] = freq
		}
	}
}

func newArrayFromCharFrequencies(charFrequencies map[rune]int) []string {
	characters := make([]string, 0)
	for char, freq := range charFrequencies {
		for i := 0; i < freq; i++ {
			characters = append(characters, string(char))
		}
	}
	return characters
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
