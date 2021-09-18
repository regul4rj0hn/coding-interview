package main

// O(v+e) time | O(v) space
// where V is the number of vertices and E is the number of edges in the graph
func TwoEdgeConnectedGraph(edges [][]int) bool {
	if len(edges) == 0 {
		return true
	}

	arrivalTimes := make([]int, len(edges))
	for i := range edges {
		arrivalTimes[i] = -1
	}
	startVertex := 0

	if getAncestorMinimumArrivalTime(startVertex, -1, 0, &arrivalTimes, edges) == -1 {
		return false
	}

	return areAllVerticesVisited(arrivalTimes)
}

func areAllVerticesVisited(arrivalTimes []int) bool {
	for _, time := range arrivalTimes {
		if time == -1 {
			return false
		}
	}
	return true
}

func getAncestorMinimumArrivalTime(vertex, parent, time int, arrivalTimes *[]int, edges [][]int) int {
	(*arrivalTimes)[vertex] = time

	var minArrivalTime = time
	for _, destination := range edges[vertex] {
		if (*arrivalTimes)[destination] == -1 {
			minArrivalTime = min(minArrivalTime, getAncestorMinimumArrivalTime(destination, vertex, time+1, arrivalTimes, edges))
		} else if destination != parent {
			minArrivalTime = min(minArrivalTime, (*arrivalTimes)[destination])
		}
	}
	// A bridge was detected, which means the graph isn't two-edge-connected
	if minArrivalTime == time && parent != -1 {
		return -1
	}

	return minArrivalTime
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
