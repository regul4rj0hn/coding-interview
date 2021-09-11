package main

// O(n.log(k)) time | O(k) space
// where N is the number of elements in the array and K is how far away the elements are from their sorted position
func SortKSortedArray(array []int, k int) []int {
	if len(array) == 0 || k == 0 {
		return array
	}
	heapArray := make([]int, min(k+1, len(array)))
	copy(heapArray, array[0:min(k+1, len(array))])
	minHeapWithKElements := NewMinHeap(heapArray)

	nextIndexToInsertElement := 0
	for i := k + 1; i < len(array); i++ {
		minElement := minHeapWithKElements.Remove()
		array[nextIndexToInsertElement] = minElement
		nextIndexToInsertElement += 1
		currentElement := array[i]
		minHeapWithKElements.Insert(currentElement)
	}

	for !minHeapWithKElements.IsEmpty() {
		minElement := minHeapWithKElements.Remove()
		array[nextIndexToInsertElement] = minElement
		nextIndexToInsertElement += 1
	}

	return array
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}

type MinHeap []int

func NewMinHeap(array []int) *MinHeap {
	heap := MinHeap(array)
	ptr := &heap
	ptr.BuildHeap(array)
	return ptr
}

func (h *MinHeap) BuildHeap(array []int) {
	first := (len(array) - 2) / 2
	for i := first + 1; i >= 0; i-- {
		h.siftDown(i, len(array)-1)
	}
}

func (h *MinHeap) siftDown(start, end int) {
	leftChildIdx := start*2 + 1
	for leftChildIdx <= end {
		rightChildIdx := -1
		if start*2+2 <= end {
			rightChildIdx = start*2 + 2
		}
		toSwap := leftChildIdx
		if rightChildIdx > -1 && (*h)[rightChildIdx] < (*h)[leftChildIdx] {
			toSwap = rightChildIdx
		}
		if (*h)[toSwap] < (*h)[start] {
			h.swap(start, toSwap)
			start = toSwap
			leftChildIdx = start*2 + 1
		} else {
			return
		}
	}
}

func (h *MinHeap) siftUp() {
	index := len(*h) - 1
	parentIndex := (index - 1) / 2
	for index > 0 {
		current, parent := (*h)[index], (*h)[parentIndex]
		if current < parent {
			h.swap(index, parentIndex)
			index = parentIndex
			parentIndex = (index - 1) / 2
		} else {
			return
		}
	}
}

func (h MinHeap) Peek() int {
	if len(h) == 0 {
		return -1
	}
	return h[0]
}

func (h *MinHeap) Remove() int {
	l := len(*h)
	h.swap(0, l-1)
	peeked := (*h)[l-1]
	*h = (*h)[0 : l-1]
	h.siftDown(0, l-2)
	return peeked
}

func (h *MinHeap) Insert(value int) {
	*h = append(*h, value)
	h.siftUp()
}

func (h *MinHeap) IsEmpty() bool {
	return len(*h) == 0
}

func (h MinHeap) swap(i, j int) {
	h[i], h[j] = h[j], h[i]
}
