// Another way of solving this problem is to realize that, for any coordinate to be a valid lower left corner of a rectangle,
// there must be a corresponding upper right corner of the same rectangle, which is just another coordinate located to the upper right of the first coordinate.
// If you have two such coordinates, you should be able to easily find whether corresponding upper left and lower right corners exist.

package main

import (
	"fmt"
)

const (
	None Direction = iota - 1
	Up
	Down
	Left
	Right
)

type Direction int
type CoordsTable map[string]struct{}

// O(n^2) time | O(n) space
// where N is the number of coordinates
func RectangleMania(coords [][]int) int {
	coordsTable := getCoordsTable(coords)
	return getRectangleCount(coords, coordsTable)
}

func getCoordsTable(coords [][]int) CoordsTable {
	table := CoordsTable{}
	for _, coord := range coords {
		table[coordToString(coord)] = struct{}{}
	}
	return table
}

func getRectangleCount(coords [][]int, table CoordsTable) int {
	count := 0
	for _, coord1 := range coords {
		for _, coord2 := range coords {
			if !isInUpperRight(coord1, coord2) {
				continue
			}
			upperCoord := []int{coord1[0], coord2[1]}
			rightCoord := []int{coord2[0], coord1[1]}
			_, found1 := table[coordToString(upperCoord)]
			_, found2 := table[coordToString(rightCoord)]
			if found1 && found2 {
				count++
			}
		}
	}
	return count
}

func isInUpperRight(coord1, coord2 []int) bool {
	return coord2[0] > coord1[0] && coord2[1] > coord1[1]
}

func coordToString(coord []int) string {
	return fmt.Sprintf("%d-%d", coord[0], coord[1])
}
