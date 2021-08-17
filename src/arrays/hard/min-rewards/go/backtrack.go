package main

// O(n^2) time | O(n) space
// where N is the length of the input array
func MinRewards(scores []int) int {
	rewards := make([]int, len(scores))
	Fill(rewards, 1)
	for i := 1; i < len(scores); i++ {
		j := i - 1
		if scores[i] > scores[j] {
			rewards[i] = rewards[j] + 1
			continue
		}
		for j >= 0 && scores[j] > scores[j+1] {
			rewards[j] = Max(rewards[j], rewards[j+1]+1)
			j--
		}
	}
	return Sum(rewards)
}
