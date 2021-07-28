package main

import (
	"math"
)

// O(n^3) time | O(n^2) space
// where N is the number of currencies
func DetectArbitrage(exchangeRates [][]float64) bool {
	logExchangeRates := convertToLogMatrix(exchangeRates)
	return foundNegativeWeightCycle(logExchangeRates, 0)
}

// Since a negative weight cycle indicates an arbitrage, we use Bellman-Ford Algorithm to detect them
// Similar to Dijkstra's, but able to handle negative weights https://en.wikipedia.org/wiki/Bellman%E2%80%93Ford_algorithm
func foundNegativeWeightCycle(graph [][]float64, start int) bool {
	distancesFromStart := make([]float64, len(graph))
	for i := range distancesFromStart {
		distancesFromStart[i] = math.MaxFloat64
	}
	distancesFromStart[start] = 0.0

	for unused := 0; unused < len(graph)-1; unused++ {
		if !relaxEdgesAndUpdateDistances(graph, distancesFromStart) {
			return false
		}
	}
	return relaxEdgesAndUpdateDistances(graph, distancesFromStart)
}

// Returns `true` if any distance was updated
// If no update occurs, that means there's no negative cycles in the graph
func relaxEdgesAndUpdateDistances(graph [][]float64, distances []float64) bool {
	var updated = false
	for sourceIdx := range graph {
		edges := graph[sourceIdx]
		for destinationIdx := range edges {
			weight := edges[destinationIdx]
			newDistanceToDestination := distances[sourceIdx] + weight
			if newDistanceToDestination < distances[destinationIdx] {
				updated = true
				distances[destinationIdx] = newDistanceToDestination
			}
		}
	}
	return updated
}

// To use exchange rates as edge weights, we must be able to add them.
// Since log(a*b) = log(a) + log(b), we can convert all rates to -log10(rate) to use them as edge weights
func convertToLogMatrix(matrix [][]float64) [][]float64 {
	newMatrix := make([][]float64, len(matrix))
	for row, rates := range matrix {
		for _, rate := range rates {
			newMatrix[row] = append(newMatrix[row], -math.Log10(rate))
		}
	}
	return newMatrix
}
