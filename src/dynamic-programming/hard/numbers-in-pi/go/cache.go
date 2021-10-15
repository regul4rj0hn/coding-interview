package main

import (
	"math"
)

// O(n^3 + m) time | O(n + m) space
// where N is the number of digits in Pi and M is the number of favorite numbers
func NumbersInPi(pi string, numbers []string) int {
	numbersTable := map[string]bool{}
	for _, number := range numbers {
		numbersTable[number] = true
	}

	cache := map[int]int{}
	for i := len(pi) - 1; i >= 0; i-- {
		getMinSpaces(pi, numbersTable, cache, i)
	}

	if cache[0] == math.MaxInt32 {
		return -1
	}

	return cache[0]
}

func getMinSpaces(pi string, numbers map[string]bool, cache map[int]int, idx int) int {
	if idx == len(pi) {
		return -1
	} else if val, found := cache[idx]; found {
		return val
	}

	minSpaces := math.MaxInt32
	for i := idx; i < len(pi); i++ {
		prefix := pi[idx : i+1]
		if _, found := numbers[prefix]; found {
			minSpacesInSuffix := getMinSpaces(pi, numbers, cache, i+1)
			minSpaces = min(minSpaces, minSpacesInSuffix+1)
		}
	}
	cache[idx] = minSpaces
	return cache[idx]
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
