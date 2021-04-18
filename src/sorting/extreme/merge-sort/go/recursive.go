// Conceptually, a merge sort works as follows:
// 1. Divide the unsorted list into N sublists, each containing one element (a list of one element is considered sorted).
// 2. Repeatedly merge sublists to produce new sorted sublists until there is only one sublist remaining. This will be the sorted list.
// Avarage and worst case performance of O(n.log(n)) time and O(n.log(n)) space
package main

func MergeSort(array []int) []int {
	if len(array) <= 1 {
		return array
	}

	center := len(array) / 2
	left := array[:center]
	right := array[center:]

	return merge(MergeSort(left), MergeSort(right))
}

func merge(left []int, right []int) []int {
	counter := 0
	var sorted = make([]int, len(left)+len(right))

	for len(left) > 0 && len(right) > 0 {
		if left[0] > right[0] {
			sorted[counter] = right[0]
			right = right[1:]
		} else {
			sorted[counter] = left[0]
			left = left[1:]
		}
		counter++
	}
	for len(left) > 0 {
		sorted[counter] = left[0]
		counter++
		left = left[1:]
	}
	for len(right) > 0 {
		sorted[counter] = right[0]
		counter++
		right = right[1:]
	}
	return sorted
}
