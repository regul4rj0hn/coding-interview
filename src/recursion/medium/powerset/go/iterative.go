package main

// O(n.2^n) time | O(n.2^n) space
func Powerset(array []int) [][]int {
	subsets := [][]int{{}}
	for _, ele := range array {
		length := len(subsets)
		for i := 0; i < length; i++ {
			current := subsets[i]
			newsub := append([]int{}, current...)
			newsub = append(newsub, ele)
			subsets = append(subsets, newsub)
		}
	}
	return subsets
}
