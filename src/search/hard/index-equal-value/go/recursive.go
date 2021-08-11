package main

// O(log(n)) time | O(log(n)) space
// where N is the length of the input array
func IndexEqualsValue(array []int) int {
	return indexEqualsValue(array, 0, len(array)-1)
}

func indexEqualsValue(array []int, left, right int) int {
	if left > right {
		return -1
	}

	mid := left + (right-left)/2
	midValue := array[mid]
	if midValue < mid {
		return indexEqualsValue(array, mid+1, right)
	}
	if midValue == mid && mid == 0 {
		return mid
	}
	if midValue == mid && array[mid-1] < mid-1 {
		return mid
	}
	return indexEqualsValue(array, left, mid-1)
}
