package main

import (
	"fmt"
	"math"
)

type Node struct {
	id                string
	row               int
	col               int
	value             int
	distanceFromStart int
	estimatedDistance int
	cameFrom          *Node
}

func newNode(row, col, value int) *Node {
	return &Node{
		id:                fmt.Sprintf("%d-%d", row, col),
		row:               row,
		col:               col,
		value:             value,
		distanceFromStart: math.MaxInt32,
		estimatedDistance: math.MaxInt32,
		cameFrom:          nil,
	}
}

func initializeNodes(graph [][]int) [][]*Node {
	nodes := make([][]*Node, 0)
	for row := range graph {
		newRow := make([]*Node, 0)
		for col := range graph[0] {
			value := graph[row][col]
			newRow = append(newRow, newNode(row, col, value))
		}
		nodes = append(nodes, newRow)
	}
	return nodes
}

func calculateManhattanDistance(currentNode *Node, endNode *Node) int {
	return abs(currentNode.col-endNode.col) + abs(currentNode.row-endNode.row)
}

func getNeighboringNodes(node *Node, nodes [][]*Node) []*Node {
	neighbors := make([]*Node, 0)
	numRows := len(nodes)
	numCols := len(nodes[0])

	row := node.row
	col := node.col

	if row < numRows-1 {
		neighbors = append(neighbors, nodes[row+1][col])
	}
	if row > 0 {
		neighbors = append(neighbors, nodes[row-1][col])
	}
	if col < numCols-1 {
		neighbors = append(neighbors, nodes[row][col+1])
	}
	if col > 0 {
		neighbors = append(neighbors, nodes[row][col-1])
	}
	return neighbors
}

func reconstructPath(endNode *Node) [][]int {
	if endNode.cameFrom == nil {
		return [][]int{}
	}

	currentNode := endNode
	path := make([][]int, 0)
	for currentNode != nil {
		path = append(path, []int{currentNode.row, currentNode.col})
		currentNode = currentNode.cameFrom
	}
	return reversePath(path)
}

func reversePath(path [][]int) [][]int {
	newPath := make([][]int, len(path))
	for i := range path {
		j := len(path) - i - 1
		newPath[i] = path[j]
	}
	return newPath
}

func abs(a int) int {
	if a > 0 {
		return a
	}
	return -a
}
