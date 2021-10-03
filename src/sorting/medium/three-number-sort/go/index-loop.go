package main

// O(n) time | O(1) space - where N is the length of the array
func ThreeNumberSort(array []int, order []int) []int {
	firstValue, thirdValue := order[0], order[2]

	firstIdx := 0
	for i := range array {
		if array[i] == firstValue {
			array[firstIdx], array[i] = array[i], array[firstIdx]
			firstIdx += 1
		}
	}

	thirdIdx := len(array) - 1
	for i := len(array) - 1; i >= 0; i-- {
		if array[i] == thirdValue {
			array[thirdIdx], array[i] = array[i], array[thirdIdx]
			thirdIdx -= 1
		}
	}
	return array
}
