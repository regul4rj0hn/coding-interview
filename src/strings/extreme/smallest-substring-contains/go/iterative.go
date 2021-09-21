package main

import (
	"math"
)

// O(b+s) time | O(b+s) space
// where B is the length of the big and S of the small input strings respectively
func SmallestSubstringContaining(bigString, smallString string) string {
	targetCharCounts := getCharCounts(smallString)
	substringBounds := getSubstringBounds(bigString, targetCharCounts)
	return getStringFromBounds(bigString, substringBounds)
}

func getCharCounts(str string) map[byte]int {
	charCounts := map[byte]int{}
	for _, char := range str {
		increaseCharCount(byte(char), charCounts)
	}
	return charCounts
}

// Move the rightIdx to the right in the string until you've counted all the target characters enough times
// Move the leftIdx to the right in the string until we no longer have enough of the target chars between
// the leftIDx and the rightIdx and update the substrings accordingly
func getSubstringBounds(str string, charCounts map[byte]int) []int {
	substringBounds := []int{0, math.MaxInt32}
	substringCharCounts := map[byte]int{}
	numUniqueChars := len(charCounts)
	numUniqueCharsDone := 0
	leftIdx := 0
	rightIdx := 0

	for rightIdx < len(str) {
		rightChar := str[rightIdx]
		if _, found := charCounts[rightChar]; !found {
			rightIdx++
			continue
		}
		increaseCharCount(rightChar, substringCharCounts)
		if substringCharCounts[rightChar] == charCounts[rightChar] {
			numUniqueCharsDone++
		}

		for numUniqueCharsDone == numUniqueChars && leftIdx <= rightIdx {
			substringBounds = getCloserBounds(leftIdx, rightIdx, substringBounds[0], substringBounds[1])
			leftChar := str[leftIdx]
			if _, found := charCounts[leftChar]; !found {
				leftIdx++
				continue
			}
			if substringCharCounts[leftChar] == charCounts[leftChar] {
				numUniqueCharsDone--
			}
			decreaseCharCount(leftChar, substringCharCounts)
			leftIdx++
		}
		rightIdx++
	}

	return substringBounds
}

func getCloserBounds(idx1, idx2, idx3, idx4 int) []int {
	if idx2-idx1 < idx4-idx3 {
		return []int{idx1, idx2}
	}
	return []int{idx3, idx4}
}

func getStringFromBounds(str string, bounds []int) string {
	start, end := bounds[0], bounds[1]
	if end == math.MaxInt32 {
		return ""
	}
	return str[start : end+1]
}

func increaseCharCount(char byte, charCounts map[byte]int) {
	charCounts[char]++
}

func decreaseCharCount(char byte, charCounts map[byte]int) {
	charCounts[char]--
}
