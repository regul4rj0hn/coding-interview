package main

// O(n) time | O(n) space - where N is the length of the input array
func WaterArea(heights []int) int {
	maxes := make([]int, len(heights))
	leftmax := 0
	for i, height := range heights {
		maxes[i] = leftmax
		leftmax = max(leftmax, height)
	}
	rightmax := 0
	for i := range heights {
		j := len(heights) - i - 1
		height := heights[j]
		minheight := min(rightmax, maxes[j])
		if height < minheight {
			maxes[j] = minheight - height
		} else {
			maxes[j] = 0
		}
		rightmax = max(rightmax, height)
	}
	return sum(maxes)
}

func min(arg int, args ...int) int {
	current := arg
	for _, num := range args {
		if num < current {
			current = num
		}
	}
	return current
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

func sum(arr []int) int {
	acc := 0
	for _, num := range arr {
		acc += num
	}
	return acc
}
