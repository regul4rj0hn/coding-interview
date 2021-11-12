package main

import (
	"sort"
)

func TandemBicycle(redShirtSpeeds []int, blueShirtSpeeds []int, fastest bool) int {
	sort.Ints(redShirtSpeeds)
	sort.Ints(blueShirtSpeeds)

	if !fastest {
		reverseArrayInPlace(redShirtSpeeds)
	}

	totalSpeed := 0
	for i := range redShirtSpeeds {
		rider1 := redShirtSpeeds[i]
		rider2 := blueShirtSpeeds[len(blueShirtSpeeds)-i-1]
		totalSpeed += max(rider1, rider2)
	}
	return totalSpeed
}

func reverseArrayInPlace(array []int) {
	var start, end = 0, len(array) - 1
	for start < end {
		tmp := array[start]
		array[start] = array[end]
		array[end] = tmp
		start, end = start+1, end-1
	}
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
