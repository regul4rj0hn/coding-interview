package main

// O(n) time | O(n) space - where N is the number of buildings
func LargestRectangleUnderSkyline(buildings []int) int {
	pillarIndices := []int{}
	var maxArea = 0

	extendedBuildings := append(buildings, 0)
	for i := range extendedBuildings {
		height := extendedBuildings[i]
		for len(pillarIndices) != 0 && buildings[pillarIndices[len(pillarIndices)-1]] >= height {
			var pillarIndex int
			pillarIndex, pillarIndices = pillarIndices[len(pillarIndices)-1], pillarIndices[:len(pillarIndices)-1]
			pillarHeight := buildings[pillarIndex]
			width := i
			if len(pillarIndices) != 0 {
				width = i - pillarIndices[len(pillarIndices)-1] - 1
			}
			maxArea = max(width*pillarHeight, maxArea)
		}
		pillarIndices = append(pillarIndices, i)
	}
	return maxArea
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
