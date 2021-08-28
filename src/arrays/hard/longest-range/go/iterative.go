package main

// O(n) time | O(n) space - where N is the length of the input array
func LargestRange(array []int) []int {
	best := []int{}
	longest := 0
	nums := map[int]bool{}
	for _, num := range array {
		nums[num] = true
	}
	for _, num := range array {
		if !nums[num] {
			continue
		}
		nums[num] = false
		length, left, right := 1, num-1, num+1
		for nums[left] {
			nums[left] = false
			length += 1
			left -= 1
		}
		for nums[right] {
			nums[right] = false
			length += 1
			right += 1
		}
		if length > longest {
			longest = length
			best = []int{left + 1, right - 1}
		}
	}
	return best
}
