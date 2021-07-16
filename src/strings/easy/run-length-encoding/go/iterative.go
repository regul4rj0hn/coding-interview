package main

import (
	"strconv"
)

// O(n) time | O(n) space
// where N is the length of the input string
func RunLengthEncoding(str string) string {
	encodedChars := []byte{}
	currentLength := 1

	for i := 1; i < len(str); i++ {
		currentChar := str[i]
		previousChar := str[i-1]

		if currentChar != previousChar || currentLength == 9 {
			encodedChars = append(encodedChars, strconv.Itoa(currentLength)[0])
			encodedChars = append(encodedChars, previousChar)
			currentLength = 0
		}
		currentLength++
	}
	encodedChars = append(encodedChars, strconv.Itoa(currentLength)[0])
	encodedChars = append(encodedChars, str[len(str)-1])

	return string(encodedChars)
}
