package main

func QuickSort(array []int) []int {
	return quickSort(array, 0, len(array)-1)
}

func quickSort(array []int, start, end int) []int {
	if start >= end {
		return array
	}

	pivot := start
	left := start + 1
	right := end
	for right >= left {
		if array[left] > array[pivot] && array[right] < array[pivot] {
			array[left], array[right] = array[right], array[left]
		}
		if array[left] <= array[pivot] {
			left += 1
		}
		if array[right] >= array[pivot] {
			right -= 1
		}
	}

	array[pivot], array[right] = array[right], array[pivot]

	if right-1-start < end-(right+1) {
		quickSort(array, start, right-1)
		quickSort(array, right+1, end)
	} else {
		quickSort(array, right+1, end)
		quickSort(array, start, right-1)
	}

	return array
}
