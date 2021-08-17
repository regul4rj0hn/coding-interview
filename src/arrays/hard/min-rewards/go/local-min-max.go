package main

// O(n) time | O(n) space
// where N is the length of the input array
func MinRewards(scores []int) int {
	rewards := make([]int, len(scores))
	Fill(rewards, 1)
	localMinIndex := getLocalMinIndices(scores)
	for _, localMinIdx := range localMinIndex {
		expandFromLocalMinIndex(localMinIdx, scores, rewards)
	}
	return Sum(rewards)
}

func getLocalMinIndices(array []int) []int {
	indices := []int{}
	if len(array) == 1 {
		indices = append(indices, 0)
		return indices
	}
	for i := 0; i < len(array); i++ {
		if i == 0 && array[i] < array[i+1] {
			indices = append(indices, i)
		}
		if i == len(array)-1 && array[i] < array[i-1] {
			indices = append(indices, i)
		}
		if i == 0 || i == len(array)-1 {
			continue
		}
		if array[i] < array[i+1] && array[i] < array[i-1] {
			indices = append(indices, i)
		}
	}
	return indices
}

func expandFromLocalMinIndex(index int, scores, rewards []int) {
	left := index - 1
	for left >= 0 && scores[left] > scores[left+1] {
		rewards[left] = Max(rewards[left], rewards[left+1]+1)
		left--
	}
	right := index + 1
	for right < len(scores) && scores[right] > scores[right-1] {
		rewards[right] = rewards[right-1] + 1
		right++
	}
}
