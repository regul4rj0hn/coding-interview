package main

type MinHeap struct {
	array               []*Node
	nodePositionsInHeap map[string]int
}

func newMinHeap(array []*Node) *MinHeap {
	nodePositionsInHeap := map[string]int{}
	for i, node := range array {
		nodePositionsInHeap[node.id] = i
	}
	heap := &MinHeap{array: array, nodePositionsInHeap: nodePositionsInHeap}
	heap.buildHeap()
	return heap
}

func (h *MinHeap) IsEmpty() bool {
	return len(h.array) == 0
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Remove() *Node {
	if h.IsEmpty() {
		return nil
	}
	h.swap(0, len(h.array)-1)

	peeked := h.array[len(h.array)-1]
	h.array = h.array[0 : len(h.array)-1]

	delete(h.nodePositionsInHeap, peeked.id)
	h.siftDown(0, len(h.array)-1)

	return peeked
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Update(node *Node) {
	h.siftUp(h.nodePositionsInHeap[node.id])
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Insert(node *Node) {
	h.array = append(h.array, node)
	h.nodePositionsInHeap[node.id] = len(h.array) - 1
	h.siftUp(len(h.array) - 1)
}

// O(log(n)) time | O(1) space
func (h *MinHeap) siftUp(index int) {
	parentIndex := (index - 1) / 2
	for index > 0 && h.array[index].estimatedDistance < h.array[parentIndex].estimatedDistance {
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
		c1Distance := h.array[leftChildIdx].estimatedDistance
		if rightChildIdx > -1 && h.array[rightChildIdx].estimatedDistance < c1Distance {
			indexToSwap = rightChildIdx
		}

		if h.array[indexToSwap].estimatedDistance < h.array[start].estimatedDistance {
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

func (h *MinHeap) containsNode(node *Node) bool {
	_, found := h.nodePositionsInHeap[node.id]
	return found
}

func (h MinHeap) swap(i, j int) {
	h.nodePositionsInHeap[h.array[i].id] = j
	h.nodePositionsInHeap[h.array[j].id] = i
	h.array[i], h.array[j] = h.array[j], h.array[i]
}
