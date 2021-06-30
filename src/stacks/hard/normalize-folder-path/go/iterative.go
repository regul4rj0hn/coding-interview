package main

import (
	"strings"
)

const (
	directorySeparator = "/"
	currentDirectory   = "."
	previousDirectory  = ".."
	rootDirectory      = ""
)

// O(n) time | O(n) space
// where N is the length of the path
func ShortenPath(path string) string {
	startsWithSlash := path[0] == '/'
	splits := strings.Split(path, directorySeparator)
	tokens := []string{}
	for _, token := range splits {
		if isValidDirectoryToken(token) {
			tokens = append(tokens, token)
		}
	}

	stack := []string{}
	if startsWithSlash {
		stack = append(stack, rootDirectory)
	}

	for _, token := range tokens {
		if token != previousDirectory {
			stack = append(stack, token)
			continue
		}
		if len(stack) == 0 || stack[len(stack)-1] == previousDirectory {
			stack = append(stack, token)
			continue
		}
		if stack[len(stack)-1] != rootDirectory {
			stack = stack[:len(stack)-1]
		}
	}

	if len(stack) == 1 && stack[0] == rootDirectory {
		return directorySeparator
	}
	return strings.Join(stack, directorySeparator)
}

func isValidDirectoryToken(token string) bool {
	return len(token) > 0 && token != currentDirectory
}
