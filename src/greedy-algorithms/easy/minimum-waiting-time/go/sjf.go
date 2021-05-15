package main

import (
	"sort"
)

func MinimumWaitingTime(queries []int) int {
	sort.Ints(queries)

	totalTime := 0
	for i, duration := range queries {
		remaining := len(queries) - (i + 1)
		totalTime += duration * remaining
	}

	return totalTime
}
