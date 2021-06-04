package main

// O(w.h.log(w.h)) time | O(w.h) space
// where W is the width and H is the height of the graph
func AStarAlgorithm(startRow int, startCol int, endRow int, endCol int, graph [][]int) [][]int {
	nodes := initializeNodes(graph)

	startNode := nodes[startRow][startCol]
	endNode := nodes[endRow][endCol]

	startNode.distanceFromStart = 0
	startNode.estimatedDistance = calculateManhattanDistance(startNode, endNode)

	nodesToVisit := newMinHeap([]*Node{startNode})

	for !nodesToVisit.IsEmpty() {
		currentMinDistanceNode := nodesToVisit.Remove()
		if currentMinDistanceNode == endNode {
			break
		}

		neighbors := getNeighboringNodes(currentMinDistanceNode, nodes)
		for _, neighbor := range neighbors {
			if neighbor.value == 1 {
				continue
			}

			tentativeDistanceToNeighbor := currentMinDistanceNode.distanceFromStart + 1
			if tentativeDistanceToNeighbor >= neighbor.distanceFromStart {
				continue
			}

			neighbor.cameFrom = currentMinDistanceNode
			neighbor.distanceFromStart = tentativeDistanceToNeighbor
			neighbor.estimatedDistance = tentativeDistanceToNeighbor + calculateManhattanDistance(neighbor, endNode)

			if !nodesToVisit.containsNode(neighbor) {
				nodesToVisit.Insert(neighbor)
			} else {
				nodesToVisit.Update(neighbor)
			}
		}
	}
	return reconstructPath(endNode)
}
