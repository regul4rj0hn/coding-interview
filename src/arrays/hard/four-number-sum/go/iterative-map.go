package main

// Average: O(n^2) time | O(n^2) space
// Worst  : O(n^3) time | O(n^2) space
func FourNumberSum(array []int, target int) [][]int {
	allPairSums := map[int][][]int{}
	quadruplets := [][]int{}
	for i := 1; i < len(array)-1; i++ {
		for j := i + 1; j < len(array); j++ {
			sum := array[i] + array[j]
			difference := target - sum
			if pairs, found := allPairSums[difference]; found {
				for _, pair := range pairs {
					quad := append(pair, array[i], array[j])
					quadruplets = append(quadruplets, quad)
				}
			}
		}
		for k := 0; k < i; k++ {
			sum := array[i] + array[k]
			allPairSums[sum] = append(allPairSums[sum], []int{array[k], array[i]})
		}
	}
	return quadruplets
}
