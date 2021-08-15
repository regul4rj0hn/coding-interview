package main

// O(log(n)) time | O(log(n)) space
func SearchForRange(array []int, target int) []int {
	output := []int{-1, -1}
	customBinarySearch(array, target, 0, len(array)-1, output, true)
	customBinarySearch(array, target, 0, len(array)-1, output, false)
	return output
}

func customBinarySearch(array []int, target, left, right int, output []int, goLeft bool) {
	if left > right {
		return
	}
	mid := (left + right) / 2
	if array[mid] < target {
		customBinarySearch(array, target, mid+1, right, output, goLeft)
		return
	}
	if array[mid] > target {
		customBinarySearch(array, target, left, mid-1, output, goLeft)
		return
	}
	if goLeft {
		if mid == 0 || array[mid-1] != target {
			output[0] = mid
		} else {
			customBinarySearch(array, target, left, mid-1, output, goLeft)
		}
	} else {
		if mid == len(array)-1 || array[mid+1] != target {
			output[1] = mid
		} else {
			customBinarySearch(array, target, mid+1, right, output, goLeft)
		}
	}
}
