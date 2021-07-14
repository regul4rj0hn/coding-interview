package main

import (
	"sort"
)

// O(n.log(n)) time | O(n) space
// where N is the number of times on the input array
func LaptopRentals(times [][]int) int {
	if len(times) == 0 {
		return 0
	}

	usedLaptops := 0
	start, end := []int{}, []int{}
	for _, time := range times {
		start = append(start, time[0])
		end = append(end, time[1])
	}
	sort.Ints(start)
	sort.Ints(end)

	startIdx, endIdx := 0, 0
	for startIdx < len(times) {
		if start[startIdx] >= end[endIdx] {
			usedLaptops -= 1
			endIdx += 1
		}
		usedLaptops += 1
		startIdx += 1
	}

	return usedLaptops
}
