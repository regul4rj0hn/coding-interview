package main

import (
	"strings"
)

type interval struct {
	left  int
	right int
}
type intervals []*interval

// Average case: O(n+m) | O(n) space
// where N is the length of the main string and M is the length of the substring
func UnderscorifySubstring(str string, substring string) string {
	locations := getLocations(str, substring)
	locations = locations.collapse()
	return underscorify(str, locations)
}

func getLocations(str, substr string) intervals {
	result := intervals{}
	for start := 0; start < len(str); {
		next := strings.Index(str[start:], substr)
		if next == -1 {
			break
		}
		next += start
		result = append(result, &interval{next, next + len(substr)})
		start = next + 1
	}
	return result
}

func (array intervals) collapse() intervals {
	if len(array) == 0 {
		return array
	}
	result := intervals{array[0]}
	previous := array[0]
	for i := 1; i < len(array); i++ {
		current := array[i]
		if current.left <= previous.right {
			previous.right = current.right
		} else {
			result = append(result, current)
			previous = current
		}
	}
	return result
}

func underscorify(str string, locations intervals) string {
	if len(locations) == 0 {
		return str
	}
	// result string will have an additional 2*len(interval) underscores
	result := make([]rune, len(str)+2*len(locations))
	resultIndex, locationIndex := 0, 0
	for i, r := range str {
		location := locations[locationIndex]
		if i == location.left {
			result[resultIndex] = '_'
			resultIndex += 1
		} else if i == location.right {
			result[resultIndex] = '_'
			resultIndex += 1
			if locationIndex+1 < len(locations) {
				locationIndex += 1
			}
		}
		result[resultIndex] = r
		resultIndex += 1
	}
	if locations[locationIndex].right == len(str) {
		result[len(result)-1] = '_'
	}
	return string(result)
}
