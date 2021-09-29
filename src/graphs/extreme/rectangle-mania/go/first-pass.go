// Treat every coordinate as the potential lower left corner of a rectangle, you can move in a clockwise pattern
// (i.e., directly up, then directly right, then directly down, and finally directly left) to try to find a rectangle.
// There are a few ways to do this, one of which involves storing, for every coordinate, all other coordinates that are directly above it,
// directly to the right of it, directly below it, and directly to the left of it.
// With this information, you can iterate through all of the coordinates and then traverse through potential rectangles in an up-right-down-left pattern.

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
type CoordsTable map[string]map[Direction][][]int

// O(n^2) time | O(n^2) space
// where N is the number of coordinates on the input matrix
func RectangleMania(coords [][]int) int {
	coordsTable := getCoordsTable(coords)
	return getRectangleCount(coords, coordsTable)
}

func getCoordsTable(coords [][]int) CoordsTable {
	table := CoordsTable{}
	for _, coord1 := range coords {
		directions := map[Direction][][]int{
			Up:    {},
			Right: {},
			Down:  {},
			Left:  {},
		}
		for _, coord2 := range coords {
			coord2Direction := getCoordDirection(coord1, coord2)
			if coord2Direction != None {
				directions[coord2Direction] = append(directions[coord2Direction], coord2)
			}
		}
		table[coordToString(coord1)] = directions
	}
	return table
}

func getCoordDirection(coord1, coord2 []int) Direction {
	if coord2[1] == coord1[1] {
		if coord2[0] > coord1[0] {
			return Right
		} else if coord2[0] < coord1[0] {
			return Left
		}
	} else if coord2[0] == coord1[0] {
		if coord2[1] > coord1[1] {
			return Up
		} else if coord2[1] < coord1[1] {
			return Down
		}
	}
	return None
}

func getRectangleCount(coords [][]int, coordsTable CoordsTable) int {
	count := 0
	for _, coord := range coords {
		count += clockwiseCountRectangles(coord, coordsTable, Up, coord)
	}
	return count
}

func clockwiseCountRectangles(coord []int, table CoordsTable, direction Direction, origin []int) int {
	if direction == Left {
		for _, element := range table[coordToString(coord)][Left] {
			if element[0] == origin[0] && element[1] == origin[1] {
				return 1
			}
		}
		return 0
	}
	rectangleCount := 0
	nextDirection := direction.NextClockwise()
	for _, nextCoord := range table[coordToString(coord)][direction] {
		rectangleCount += clockwiseCountRectangles(nextCoord, table, nextDirection, origin)
	}
	return rectangleCount
}

func (d Direction) NextClockwise() Direction {
	switch d {
	case Up:
		return Right
	case Right:
		return Down
	case Down:
		return Left
	case Left:
		return Up
	}
	return None
}

func coordToString(coord []int) string {
	return fmt.Sprintf("%d-%d", coord[0], coord[1])
}
