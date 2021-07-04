package main

import (
	"strings"
)

// O(n) time | O(n) space
// where N is the length of the string
func ReverseWordsInString(str string) string {
	words := make([]string, 0)
	start := 0
	for i, char := range str {
		if char == ' ' {
			words = append(words, str[start:i])
			start = i
			continue
		}
		if str[start] == ' ' {
			words = append(words, " ")
			start = i
		}
	}

	words = append(words, str[start:])
	reverseList(words)
	return strings.Join(words, "")
}

func reverseList(list []string) {
	start := 0
	end := len(list) - 1
	for start < end {
		temp := list[start]
		list[start] = list[end]
		list[end] = temp
		start += 1
		end -= 1
	}
}
