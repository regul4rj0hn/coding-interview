package main

// O(w^2*h) time | O(w) space
// where W and H are the width and height of the input array
// -1 to represents water and 1 represents a block
func WaterfallStreams(array [][]float64, source int) []float64 {
	rowAbove := array[0]
	rowAbove[source] = -1

	for row := 1; row < len(array); row++ {
		currentRow := array[row]
		for i := range rowAbove {
			valueAbove := rowAbove[i]
			hasWaterAbove := valueAbove < 0
			hasBlock := currentRow[i] == 1

			if !hasWaterAbove {
				continue
			}
			if !hasBlock {
				currentRow[i] += valueAbove
				continue
			}
			splitWater := valueAbove / 2

			// Move water right
			var rightIdx = i
			for rightIdx+1 < len(rowAbove) {
				rightIdx += 1
				if rowAbove[rightIdx] == 1.0 {
					break
				}
				if currentRow[rightIdx] != 1.0 {
					currentRow[rightIdx] += splitWater
					break
				}
			}
			// Move water left
			var leftIdx = i
			for leftIdx-1 >= 0 {
				leftIdx -= 1
				if rowAbove[leftIdx] == 1.0 {
					break
				}
				if currentRow[leftIdx] != 1.0 {
					currentRow[leftIdx] += splitWater
					break
				}
			}
		}
		rowAbove = currentRow
	}

	finalPercentages := make([]float64, 0, len(rowAbove))
	for _, num := range rowAbove {
		if num == 0 {
			finalPercentages = append(finalPercentages, num)
		} else {
			finalPercentages = append(finalPercentages, num*-100)
		}
	}
	return finalPercentages
}
