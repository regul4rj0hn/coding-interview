package main

const (
	None Direction = iota - 1
	Up
	Down
	Left
	Right
)

type Direction int
type CoordsTable struct {
	Xs, Ys map[int][][]int
}

// O(n^2) time | O(n) space
// where N is the number of coordinates
func RectangleMania(coords [][]int) int {
	coordsTable := getCoordsTable(coords)
	return getRectangleCount(coords, coordsTable)
}

func getCoordsTable(coords [][]int) CoordsTable {
	table := CoordsTable{
		Xs: map[int][][]int{},
		Ys: map[int][][]int{},
	}
	for _, coord := range coords {
		x, y := coord[0], coord[1]
		table.Xs[x] = append(table.Xs[x], coord)
		table.Ys[y] = append(table.Ys[y], coord)
	}
	return table
}

func getRectangleCount(coords [][]int, table CoordsTable) int {
	count := 0
	for _, coord := range coords {
		lowerLeftY := coord[1]
		count += clockwiseCountRectangles(coord, table, Up, lowerLeftY)
	}
	return count
}

func clockwiseCountRectangles(coord []int, table CoordsTable, direction Direction, lowerLeftY int) int {
	if direction == Down {
		relevantCoords := table.Xs[coord[0]]
		for _, coord2 := range relevantCoords {
			lowerRightY := coord2[1]
			if lowerRightY == lowerLeftY {
				return 1
			}
		}
		return 0
	}

	if direction == Up {
		rectangleCount := 0
		relevantCoords := table.Xs[coord[0]]
		for _, coord2 := range relevantCoords {
			if coord2[1] > coord[1] {
				rectangleCount += clockwiseCountRectangles(coord2, table, Right, lowerLeftY)
			}
		}
		return rectangleCount
	}

	if direction == Right {
		rectangleCount := 0
		relevantCoords := table.Ys[coord[1]]
		for _, coord2 := range relevantCoords {
			if coord2[0] > coord[0] {
				rectangleCount += clockwiseCountRectangles(coord2, table, Down, lowerLeftY)
			}
		}
		return rectangleCount
	}
	return 0
}
