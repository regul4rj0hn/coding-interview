package main

// O(n) time | O(n) space
// whare N is the leng
func SunsetViews(buildings []int, direction string) []int {
	candidateBuildings := make([]int, 0)
	start := len(buildings) - 1

	step := -1
	if direction == "EAST" {
		start = 0
		step = 1
	}

	var i = start
	for i >= 0 && i < len(buildings) {
		height := buildings[i]
		for len(candidateBuildings) > 0 && buildings[candidateBuildings[len(candidateBuildings)-1]] <= height {
			candidateBuildings = candidateBuildings[:len(candidateBuildings)-1]
		}
		candidateBuildings = append(candidateBuildings, i)
		i += step
	}

	if direction == "WEST" {
		reverse(candidateBuildings)
	}

	return candidateBuildings
}

func reverse(array []int) {
	l := len(array) - 1
	for i := 0; i < len(array)/2; i++ {
		array[i], array[l-i] = array[l-i], array[i]
	}
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
