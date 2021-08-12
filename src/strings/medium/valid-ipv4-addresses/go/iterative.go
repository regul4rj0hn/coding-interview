package main

import (
	"strconv"
	"strings"
)

// O(1) time | O(1) space
func ValidIPAddresses(str string) []string {
	ips := make([]string, 0)

	for i := 1; i < min(len(str), 4); i++ {
		ipParts := []string{"", "", "", ""}
		ipParts[0] = str[:i]
		if !isValidPart(ipParts[0]) {
			continue
		}

		for j := i + 1; j < i+min(len(str)-i, 4); j++ {
			ipParts[1] = str[i:j]
			if !isValidPart(ipParts[1]) {
				continue
			}

			for k := j + 1; k < j+min(len(str)-j, 4); k++ {
				ipParts[2] = str[j:k]
				ipParts[3] = str[k:]
				if isValidPart(ipParts[2]) && isValidPart(ipParts[3]) {
					ips = append(ips, strings.Join(ipParts, "."))
				}
			}
		}
	}
	return ips
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}

func isValidPart(str string) bool {
	i, err := strconv.Atoi(str)
	if err != nil {
		return false
	}
	if i > 255 {
		return false
	}
	return len(str) == len(strconv.Itoa(i))
}
