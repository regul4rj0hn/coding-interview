package main

// O(n) time | O(n) space - where N is the length of the input array
func WaterArea(heights []int) int {
	if len(heights) == 0 {
		return 0
	}

	leftIdx := 0
	rightIdx := len(heights) - 1
	leftMax := heights[leftIdx]
	rightMax := heights[rightIdx]
	surfaceArea := 0
	for leftIdx < rightIdx {
		if heights[leftIdx] < heights[rightIdx] {
			leftIdx++
			leftMax = max(leftMax, heights[leftIdx])
			surfaceArea += leftMax - heights[leftIdx]
		} else {
			rightIdx--
			rightMax = max(rightMax, heights[rightIdx])
			surfaceArea += rightMax - heights[rightIdx]
		}
	}

	return surfaceArea
}

func max(arg int, args ...int) int {
	current := arg
	for _, num := range args {
		if num > current {
			current = num
		}
	}
	return current
}
