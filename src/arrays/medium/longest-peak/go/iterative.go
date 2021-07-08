package main

// O(n) time | O(1) space
// where N is the length of the input array
func LongestPeak(array []int) int {
	tallestPeak := 0
	i := 1
	for i < len(array)-1 {
		isPeak := array[i-1] < array[i] && array[i] > array[i+1]
		if !isPeak {
			i += 1
			continue
		}

		leftIdx := i - 2
		for leftIdx >= 0 && array[leftIdx] < array[leftIdx+1] {
			leftIdx -= 1
		}

		rightIdx := i + 2
		for rightIdx < len(array) && array[rightIdx] < array[rightIdx-1] {
			rightIdx += 1
		}

		currentPeak := rightIdx - leftIdx - 1
		if currentPeak > tallestPeak {
			tallestPeak = currentPeak
		}
		i = rightIdx
	}
	return tallestPeak
}
