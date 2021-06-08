package main

import (
	"sort"
)

func NonConstructibleChange(coins []int) int {
	sort.Ints(coins)

	currentChange := 0
	for _, coin := range coins {
		if coin > currentChange+1 {
			return currentChange + 1
		}
		currentChange += coin
	}

	return currentChange + 1
}
