// Pick any two points that don't have the same x or y values
// (i.e., points that could be at opposite ends of a rectangle diagonal)
// and see if we can create a rectangle with them and two other points.
// Given two points where p1 = (x1, y1) and p2 = (x2, y2), if points
// p3 = (x1, y2) and p4 = (x2, y1) exist, then these 4 points form a rectangle.
package main

import (
	"fmt"
	"math"
)

// O(n^2) time | O(n) space - where N is the number of points
func MinimumAreaRectangle(points [][]int) int {
	pointSet := createPointSet(points)
	minimumAreaFound := math.MaxInt32

	for current := range points {
		p2x, p2y := points[current][0], points[current][1]
		for prev := 0; prev < current; prev++ {
			p1x, p1y := points[prev][0], points[prev][1]

			pointsShareValue := p1x == p2x || p1y == p2y
			if pointsShareValue {
				continue
			}
			// if (p1x, p2y) and (p2x, p1y) exist, then we've found a rectangle
			point1OnOppositeDiagonalExists := pointSet[convertPointToString(p1x, p2y)]
			point2OnOppositeDiagonalExists := pointSet[convertPointToString(p2x, p1y)]
			oppositeDiagonalExists := point1OnOppositeDiagonalExists && point2OnOppositeDiagonalExists
			if oppositeDiagonalExists {
				currentArea := abs(p2x-p1x) * abs(p2y-p1y)
				minimumAreaFound = min(minimumAreaFound, currentArea)
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

func abs(a int) int {
	if a < 0 {
		return -a
	}
	return a
}

func createPointSet(points [][]int) map[string]bool {
	pointSet := map[string]bool{}
	for _, point := range points {
		x, y := point[0], point[1]
		pointString := convertPointToString(x, y)
		pointSet[pointString] = true
	}
	return pointSet
}

func convertPointToString(x, y int) string {
	return fmt.Sprintf("%d:%d", x, y)
}
