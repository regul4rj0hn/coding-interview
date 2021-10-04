//  The brute-force approach to this problem is to simply generate all possible
// combinations of 4 points and to see if they form a rectangle, the calculate
// the area of all of these rectangles and return the minimum area we can find.

// A more optimal approach (implemented below) is to find vertical or horizontal
// edges that are parallel to the y or x axes, respectively. If we find two parallel
// edges (two vertical edges, for example) that share a vertical or horizontal
// coordinate (y values in the case of vertical edges), then those edges form a rectangle.
package main

import (
	"fmt"
	"math"
	"sort"
)

// O(n^2) time | O(n) space - where N is the number of points
func MinimumAreaRectangle(points [][]int) int {
	columns := initializeColumns(points)
	minimumAreaFound := math.MaxInt32
	edgesParallelToYAxis := map[string]int{}

	sortedColumns := make([]int, 0)
	for k := range columns {
		sortedColumns = append(sortedColumns, k)
	}
	sort.Ints(sortedColumns)

	for _, x := range sortedColumns {
		yValuesInCurrentColumn := columns[x]
		sort.Ints(yValuesInCurrentColumn)

		for currentIdx := range yValuesInCurrentColumn {
			y2 := yValuesInCurrentColumn[currentIdx]
			for previousIdx := 0; previousIdx < currentIdx; previousIdx++ {
				y1 := yValuesInCurrentColumn[previousIdx]
				pointString := fmt.Sprintf("%d:%d", y1, y2)
				if _, found := edgesParallelToYAxis[pointString]; found {
					currentArea := (x - edgesParallelToYAxis[pointString]) * (y2 - y1)
					minimumAreaFound = min(minimumAreaFound, currentArea)
				}
				edgesParallelToYAxis[pointString] = x
			}
		}
	}
	if minimumAreaFound != math.MaxInt32 {
		return minimumAreaFound
	}
	return 0
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}

func initializeColumns(points [][]int) map[int][]int {
	columns := map[int][]int{}
	for _, point := range points {
		x, y := point[0], point[1]
		columns[x] = append(columns[x], y)
	}
	return columns
}
