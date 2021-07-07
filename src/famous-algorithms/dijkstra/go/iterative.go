package main

import (
	"math"
)

// O(v^2 + e) time | O(v) space
// where V is the number of vertices and E is the number of edges in the input graph
func DijkstrasAlgorithm(start int, edges [][][]int) []int {
	numVertices := len(edges)

	minDistance := make([]int, 0, len(edges))
	for range edges {
		minDistance = append(minDistance, math.MaxInt32)
	}
	minDistance[start] = 0

	visited := map[int]bool{}
	for len(visited) != numVertices {
		vertex, currentMinDistance := getVertexMinDistance(minDistance, visited)
		if currentMinDistance == math.MaxInt32 {
			break
		}

		visited[vertex] = true
		for _, edge := range edges[vertex] {
			destination, distanceToDest := edge[0], edge[1]
			if visited[destination] {
				continue
			}
			newPathDistance := currentMinDistance + distanceToDest
			currentDestDistance := minDistance[destination]
			if newPathDistance < currentDestDistance {
				minDistance[destination] = newPathDistance
			}
		}
	}

	finalDistances := make([]int, 0, len(minDistance))
	for _, distance := range minDistance {
		if distance == math.MaxInt32 {
			finalDistances = append(finalDistances, -1)
		} else {
			finalDistances = append(finalDistances, distance)
		}
	}
	return finalDistances
}

func getVertexMinDistance(distances []int, visited map[int]bool) (int, int) {
	minDistance := math.MaxInt32
	vertex := -1
	for vertexIdx, distance := range distances {
		if visited[vertexIdx] {
			continue
		}
		if distance <= minDistance {
			vertex = vertexIdx
			minDistance = distance
		}
	}
	return vertex, minDistance
}
