package main

import (
	"math"
)

func MinNumberOfCoinsForChange(n int, denoms []int) int {
	coins := make([]int, n+1)
	for i := range coins {
		coins[i] = math.MaxInt32
	}
	coins[0] = 0
	for _, denom := range denoms {
		for amount := range coins {
			if denom <= amount {
				coins[amount] = min(coins[amount], coins[amount-denom]+1)
			}
		}
	}
	if coins[n] != math.MaxInt32 {
		return coins[n]
	}
	return -1
}

func min(arg int, args ...int) int {
	output := arg
	for _, num := range args {
		if num < output {
			output = num
		}
	}
	return output
}
