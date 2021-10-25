package main

import (
	"math"
)

// O(n.k) time | O(n.k) space
func MaxProfitWithKTransactions(prices []int, k int) int {
	if len(prices) == 0 {
		return 0
	}
	profits := make([][]int, k+1)
	for i := range profits {
		profits[i] = make([]int, len(prices))
	}
	for t := 1; t < k+1; t++ {
		currentMax := math.MinInt32
		for d := 1; d < len(prices); d++ {
			currentMax = max(currentMax, profits[t-1][d-1]-prices[d-1])
			profits[t][d] = max(profits[t][d-1], currentMax+prices[d])
		}
	}
	return profits[k][len(prices)-1]
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
