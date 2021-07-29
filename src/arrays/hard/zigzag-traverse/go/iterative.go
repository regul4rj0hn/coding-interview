package main

// O(n) time | O(n) space
// where N is the total number of elements in the 2D array
func ZigzagTraverse(array [][]int) []int {
	if len(array) == 0 {
		return []int{}
	}

	height := len(array) - 1
	width := len(array[0]) - 1
	result := []int{}
	row, col := 0, 0
	goingDown := true
	for !isOutOfBounds(row, col, height, width) {
		result = append(result, array[row][col])
		if goingDown {
			if col == 0 || row == height {
				goingDown = false
				if row == height {
					col++
				} else {
					row++
				}
			} else {
				row++
				col--
			}
		} else {
			if row == 0 || col == width {
				goingDown = true
				if col == width {
					row++
				} else {
					col++
				}
			} else {
				row--
				col++
			}
		}
	}
	return result
}

func isOutOfBounds(row, col, height, width int) bool {
	return row < 0 || row > height || col < 0 || col > width
}
