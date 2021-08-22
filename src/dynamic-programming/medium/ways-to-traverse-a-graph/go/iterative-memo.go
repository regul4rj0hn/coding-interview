package main

// O(n.m) time | O(n.m) space
func NumberOfWaysToTraverseGraph(width int, height int) int {
	ways := make([][]int, height+1)
	for i := range ways {
		ways[i] = make([]int, width+1)
	}

	for widthIdx := 1; widthIdx < width+1; widthIdx++ {
		for heightIdx := 1; heightIdx < height+1; heightIdx++ {
			if widthIdx == 1 || heightIdx == 1 {
				ways[heightIdx][widthIdx] = 1
			} else {
				left := ways[heightIdx][widthIdx-1]
				up := ways[heightIdx-1][widthIdx]
				ways[heightIdx][widthIdx] = left + up
			}
		}
	}
	return ways[height][width]
}
