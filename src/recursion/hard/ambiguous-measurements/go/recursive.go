package main

import (
	"fmt"
)

// O(low.high.n) time | O(low.high) space
// where N is the number of measuring cups and low/high are the input parameters
func AmbiguousMeasurements(measuringCups [][]int, low int, high int) bool {
	memoize := map[string]bool{}
	return canMeasureInRange(measuringCups, low, high, memoize)
}

func canMeasureInRange(cups [][]int, low, high int, memo map[string]bool) bool {
	key := createHashKey(low, high)

	if val, found := memo[key]; found {
		return val
	}

	if low <= 0 && high <= 0 {
		return false
	}

	canMeasure := false
	for _, cup := range cups {
		cupLow, cupHigh := cup[0], cup[1]
		if low <= cupLow && cupHigh <= high {
			canMeasure = true
			break
		}
		newLow := max(0, low-cupLow)
		newHigh := max(0, high-cupHigh)
		canMeasure = canMeasureInRange(cups, newLow, newHigh, memo)
		if canMeasure {
			break
		}
	}
	memo[key] = canMeasure
	return canMeasure
}

func createHashKey(low, high int) string {
	return fmt.Sprintf("%d:%d", low, high)
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
