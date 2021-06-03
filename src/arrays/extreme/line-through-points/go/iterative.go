package main

import (
	"fmt"
)

// O(n^2) time | O(n) space
// where N is the number of points in the input array
func LineThroughPoints(points [][]int) int {
	maxPoints := 1

	for i, p1 := range points {
		slopes := map[string]int{}
		for j := i + 1; j < len(points); j++ {
			p2 := points[j]
			rise, run := getLineSlopeBetweenPoints(p1, p2)
			key := createHashForRational(rise, run)
			if slopes[key] == 0 {
				slopes[key] = 1
			}
			slopes[key] += 1
		}
		currentMaxPoints := maxSlope(slopes)
		maxPoints = max(maxPoints, currentMaxPoints)
	}
	return maxPoints
}

func getLineSlopeBetweenPoints(p1, p2 []int) (int, int) {
	p1x, p1y := p1[0], p1[1]
	p2x, p2y := p2[0], p2[1]

	if p1x == p2x {
		return 1, 0
	}

	var xDiff = p1x - p2x
	var yDiff = p1y - p2y
	gcd := getGreatestCommonDivisor(abs(xDiff), abs(yDiff))
	xDiff = xDiff / gcd
	yDiff = yDiff / gcd
	if xDiff < 0 {
		xDiff *= -1
		yDiff *= -1
	}

	return yDiff, xDiff
}

func createHashForRational(numerator, denominator int) string {
	return fmt.Sprintf("%d:%d", numerator, denominator)
}

func maxSlope(slopes map[string]int) int {
	currentMax := 0
	for _, slope := range slopes {
		currentMax = max(slope, currentMax)
	}
	return currentMax
}

func getGreatestCommonDivisor(num1, num2 int) int {
	a := num1
	b := num2
	for {
		if a == 0 {
			return b
		}
		if b == 0 {
			return a
		}
		a, b = b, a%b
	}
}

func max(a, b int) int {
	if a > b {
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
