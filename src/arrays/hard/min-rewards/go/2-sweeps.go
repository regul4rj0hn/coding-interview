package main

// O(n) time | O(n) space
// where N is the length of the input array
func MinRewards(scores []int) int {
	rewards := make([]int, len(scores))
	Fill(rewards, 1)
	for i := 1; i < len(scores); i++ {
		if scores[i] > scores[i-1] {
			rewards[i] = rewards[i-1] + 1
		}
	}
	for i := len(scores) - 2; i >= 0; i-- {
		if scores[i] > scores[i+1] {
			rewards[i] = Max(rewards[i], rewards[i+1]+1)
		}
	}
	return Sum(rewards)
}
