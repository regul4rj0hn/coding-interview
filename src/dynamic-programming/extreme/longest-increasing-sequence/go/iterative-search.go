package main

// O(n.log(n)) time | O(n) space
// where N is the length of the input array
func LongestIncreasingSubsequence(input []int) []int {
	sequences := make([]int, len(input))
	indices := make([]int, len(input)+1)
	for i := range input {
		sequences[i] = -1
		indices[i] = -1
	}

	length := 0
	for i, num := range input {
		newLength := binarySearch(1, length, indices, input, num)
		sequences[i] = indices[newLength-1]
		indices[newLength] = i
		length = max(length, newLength)
	}
	return buildSequence(input, sequences, indices[length])
}

func binarySearch(start, end int, indices, array []int, target int) int {
	if start > end {
		return start
	}
	mid := (start + end) / 2
	if array[indices[mid]] < target {
		start = mid + 1
	} else {
		end = mid - 1
	}
	return binarySearch(start, end, indices, array, target)
}

func buildSequence(array, sequences []int, index int) []int {
	out := []int{}
	for index != -1 {
		out = append(out, array[index])
		index = sequences[index]
	}
	reverse(out)
	return out
}

func max(arg int, rest ...int) int {
	for _, num := range rest {
		if num > arg {
			arg = num
		}
	}
	return arg
}

func reverse(numbers []int) {
	for i, j := 0, len(numbers)-1; i < j; i, j = i+1, j-1 {
		numbers[i], numbers[j] = numbers[j], numbers[i]
	}
}
