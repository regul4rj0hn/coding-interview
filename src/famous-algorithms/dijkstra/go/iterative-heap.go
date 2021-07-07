package main

import (
	"math"
)

type Item struct {
	Vertex   int
	Distance int
}

// O((v + e) * log(v)) time | O(v) space
// where V is the number of vertices and E is the number of edges in the input graph
func DijkstrasAlgorithm(start int, edges [][][]int) []int {
	numVertices := len(edges)

	minDistance := make([]int, 0, numVertices)
	for range edges {
		minDistance = append(minDistance, math.MaxInt32)
	}
	minDistance[start] = 0

	minDistancePairs := make([]Item, 0, numVertices)
	for i := range edges {
		minDistancePairs = append(minDistancePairs, Item{i, math.MaxInt32})
	}
	minDistanceHeap := NewMinHeap(minDistancePairs)
	minDistanceHeap.Update(start, 0)

	for !minDistanceHeap.IsEmpty() {
		vertex, currentMinDistance := minDistanceHeap.Remove()
		if currentMinDistance == math.MaxInt32 {
			break
		}

		for _, edge := range edges[vertex] {
			destination, distanceToDest := edge[0], edge[1]
			newPathDistance := currentMinDistance + distanceToDest
			currentDestDistance := minDistance[destination]
			if newPathDistance < currentDestDistance {
				minDistance[destination] = newPathDistance
				minDistanceHeap.Update(destination, newPathDistance)
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

// Min Heap
type MinHeap struct {
	array     []Item
	vertexMap map[int]int
}

func NewMinHeap(array []Item) *MinHeap {
	vertexMap := map[int]int{}
	for _, item := range array {
		vertexMap[item.Vertex] = item.Vertex
	}
	heap := &MinHeap{array: array, vertexMap: vertexMap}
	heap.buildHeap()
	return heap
}

func (h *MinHeap) IsEmpty() bool {
	return h.length() == 0
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Remove() (int, int) {
	l := h.length()
	h.swap(0, l-1)
	peeked := h.array[l-1]
	h.array = h.array[0 : l-1]
	delete(h.vertexMap, peeked.Vertex)
	h.siftDown(0, l-2)

	return peeked.Vertex, peeked.Distance
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Update(vertex, value int) {
	h.array[h.vertexMap[vertex]] = Item{vertex, value}
	h.siftUp(h.vertexMap[vertex])
}

// O(log(n)) time | O(1) space
func (h *MinHeap) siftUp(index int) {
	parentIndex := (index - 1) / 2
	for index > 0 && h.array[index].Distance < h.array[parentIndex].Distance {
		h.swap(index, parentIndex)
		index = parentIndex
		parentIndex = (index - 1) / 2
	}
}

// O(log(n)) time | O(1) space
func (h *MinHeap) siftDown(start, end int) {
	leftChildIdx := start*2 + 1
	for leftChildIdx <= end {
		rightChildIdx := -1
		if start*2+2 <= end {
			rightChildIdx = start*2 + 2
		}
		indexToSwap := leftChildIdx
		if rightChildIdx > -1 && h.array[rightChildIdx].Distance < h.array[leftChildIdx].Distance {
			indexToSwap = rightChildIdx
		}

		if h.array[indexToSwap].Distance < h.array[start].Distance {
			h.swap(start, indexToSwap)
			start = indexToSwap
			leftChildIdx = start*2 + 1
		} else {
			return
		}
	}
}

// O(n) time | O(1) space
func (h *MinHeap) buildHeap() {
	first := (len(h.array) - 2) / 2
	for index := first + 1; index >= 0; index-- {
		h.siftDown(index, len(h.array)-1)
	}
}

func (h MinHeap) length() int {
	return len(h.array)
}

func (h MinHeap) swap(i, j int) {
	h.vertexMap[h.array[i].Vertex] = j
	h.vertexMap[h.array[j].Vertex] = i
	h.array[i], h.array[j] = h.array[j], h.array[i]
}
