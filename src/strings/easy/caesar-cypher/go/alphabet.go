package main

import (
	"strings"
)

// O(n) time | O(n) space
func CaesarCipherEncryptor(str string, key int) string {
	runes := []rune(str)
	alphabet := "abcdefghijklmnopqrstuvwxyz"
	for i, char := range runes {
		index := strings.Index(alphabet, string(char))
		if index == -1 {
			return ""
		}
		shift := (index + key) % 26
		runes[i] = rune(alphabet[shift])
	}
	return string(runes)
}
