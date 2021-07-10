package main

import (
	"sort"
)

func MergeOverlappingIntervals(intervals [][]int) [][]int {
	sorted := make([][]int, len(intervals))
	copy(sorted, intervals)
	sort.Slice(sorted, func(i, j int) bool {
		return sorted[i][0] < sorted[j][0]
	})

	merged := make([][]int, 0)
	current := sorted[0]
	merged = append(merged, current)

	for _, next := range sorted {
		currentEnd := current[1]
		nextStart, nextEnd := next[0], next[1]
		if currentEnd >= nextStart {
			current[1] = max(currentEnd, nextEnd)
		} else {
			current = next
			merged = append(merged, current)
		}
	}

	return merged
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
