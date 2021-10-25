package main

import (
	"math"
)

// O(n.k) time | O(n) space
func MaxProfitWithKTransactions(prices []int, k int) int {
	if len(prices) == 0 {
		return 0
	}
	evenProfit := make([]int, len(prices))
	oddProfit := make([]int, len(prices))
	var currentProfits, previousProfits []int
	for t := 1; t < k+1; t++ {
		currentMax := math.MinInt32
		if t%2 == 1 {
			currentProfits, previousProfits = oddProfit, evenProfit
		} else {
			currentProfits, previousProfits = evenProfit, oddProfit
		}
		for d := 1; d < len(prices); d++ {
			currentMax = max(currentMax, previousProfits[d-1]-prices[d-1])
			currentProfits[d] = max(currentProfits[d-1], currentMax+prices[d])
		}
	}
	if k%2 == 0 {
		return evenProfit[len(prices)-1]
	}
	return oddProfit[len(prices)-1]
}

func max(arg int, args ...int) int {
	current := arg
	for _, num := range args {
		if current < num {
			current = num
		}
	}
	return current
}
