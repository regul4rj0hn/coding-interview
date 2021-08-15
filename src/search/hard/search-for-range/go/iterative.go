package main

// O(log(n)) time | O(1) space
func SearchForRange(array []int, target int) []int {
	output := []int{-1, -1}
	customBinarySearch(array, target, 0, len(array)-1, output, true)
	customBinarySearch(array, target, 0, len(array)-1, output, false)
	return output
}

func customBinarySearch(array []int, target, left, right int, output []int, goLeft bool) {
	for left <= right {
		mid := (left + right) / 2
		if array[mid] < target {
			left = mid + 1
			continue
		}
		if array[mid] > target {
			right = mid - 1
			continue
		}
		if goLeft {
			if mid == 0 || array[mid-1] != target {
				output[0] = mid
				return
			}
			right = mid - 1
		} else {
			if mid == len(array)-1 || array[mid+1] != target {
				output[1] = mid
				return
			}
			left = mid + 1
		}
	}
}
