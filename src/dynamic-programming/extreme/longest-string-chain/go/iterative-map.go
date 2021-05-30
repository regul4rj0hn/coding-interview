// For every string, imagine the longest string chain that starts with it
// Set up every string to point to the next string in its respective longest string chain.
// Additionally, keep track of the lengths of these longest string chains.
// Once information is gathered sort the strings based on their length so that whenever we visit a string
// as we iterate through them from left to right, we can have the longest string chains of any smaller strings already computed.
package main

import (
	"sort"
)

type Chain struct {
	NextString string
	MaxLength  int
}

// O(n.m^2 + n.log(n)) time | O(n.m) space
// Where N is the number of strings and M is the length of the longest string
func LongestStringChain(strings []string) []string {
	stringChains := map[string]*Chain{}
	for _, str := range strings {
		stringChains[str] = &Chain{NextString: "", MaxLength: 1}
	}

	sort.Slice(strings, func(i, j int) bool {
		return len(strings[i]) < len(strings[j])
	})
	sortedStrings := strings

	for _, str := range sortedStrings {
		findLongestStringChain(str, stringChains)
	}

	return buildLongestStringChain(strings, stringChains)
}

// Try removing every letter of the current string to see if the remaining strings form a string chain
func findLongestStringChain(str string, stringChains map[string]*Chain) {
	for i := range str {
		shorterString := getShorterString(str, i)
		if _, found := stringChains[shorterString]; !found {
			continue
		}
		tryUpdateLongestStringChain(str, shorterString, stringChains)
	}
}

func getShorterString(str string, index int) string {
	return str[:index] + str[index+1:]
}

// Update the string chain of the current string only if the shorter string leads to a longer string chain
func tryUpdateLongestStringChain(currentString, shorterString string, stringChains map[string]*Chain) {
	shorterStringChainLength := stringChains[shorterString].MaxLength
	currentStringChainLength := stringChains[currentString].MaxLength
	if shorterStringChainLength+1 > currentStringChainLength {
		stringChains[currentString].NextString = shorterString
		stringChains[currentString].MaxLength = shorterStringChainLength + 1
	}
}

// Find the string that starts the longest string chain and build the longest string chain from there
func buildLongestStringChain(strings []string, stringChains map[string]*Chain) []string {
	maxChainLength := 0
	chainStartingString := ""
	for _, str := range strings {
		if stringChains[str].MaxLength > maxChainLength {
			maxChainLength = stringChains[str].MaxLength
			chainStartingString = str
		}
	}

	longestStringChain := []string{}
	currentString := chainStartingString
	for currentString != "" {
		longestStringChain = append(longestStringChain, currentString)
		currentString = stringChains[currentString].NextString
	}
	if len(longestStringChain) == 1 {
		return []string{}
	}
	return longestStringChain
}
