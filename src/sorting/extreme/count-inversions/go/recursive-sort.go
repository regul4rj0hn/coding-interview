package main

// O(n.log(n)) time | O(n) space
// where N is the length of the array
func CountInversions(array []int) int {
	return countSubArrayInversions(array, 0, len(array))
}

func countSubArrayInversions(array []int, start, end int) int {
	if end-start <= 1 {
		return 0
	}

	middle := start + (end-start)/2
	leftInversions := countSubArrayInversions(array, start, middle)
	rightInversions := countSubArrayInversions(array, middle, end)
	mergedInversions := mergeSortAndCountInversions(array, start, middle, end)

	return leftInversions + rightInversions + mergedInversions
}

func mergeSortAndCountInversions(array []int, start, mid, end int) int {
	sortedArray := make([]int, 0)
	left := start
	right := mid
	inversions := 0

	for left < mid && right < end {
		if array[left] <= array[right] {
			sortedArray = append(sortedArray, array[left])
			left += 1
		} else {
			inversions += mid - left
			sortedArray = append(sortedArray, array[right])
			right += 1
		}
	}

	sortedArray = append(sortedArray, array[left:mid]...)
	sortedArray = append(sortedArray, array[right:end]...)
	for i := range sortedArray {
		num := sortedArray[i]
		array[start+i] = num
	}

	return inversions
}
