package main

import (
	"math"
)

type Block map[string]bool

// O(b^2.r) time | O(b) space
// where B is the number of blocks and R is the number of requirements
func ApartmentHunting(blocks []Block, reqs []string) int {
	maxDistancesAtBlocks := make([]int, len(blocks))
	for i := range blocks {
		maxDistancesAtBlocks[i] = -1
		for _, req := range reqs {
			closestReqDistance := math.MaxInt32
			for j := range blocks {
				if blocks[j][req] {
					closestReqDistance = min(closestReqDistance, distanceBetween(i, j))
				}
			}
			maxDistancesAtBlocks[i] = max(maxDistancesAtBlocks[i], closestReqDistance)
		}
	}

	var optimalBlockIdx int
	smallestMaxDistance := math.MaxInt32
	for i, currentDistance := range maxDistancesAtBlocks {
		if currentDistance < smallestMaxDistance {
			smallestMaxDistance = currentDistance
			optimalBlockIdx = i
		}
	}
	return optimalBlockIdx
}

func distanceBetween(a, b int) int {
	if a > b {
		return a - b
	}
	return b - a
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
