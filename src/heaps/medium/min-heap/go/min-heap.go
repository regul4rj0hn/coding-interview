package main

type MinHeap []int

func NewMinHeap(array []int) *MinHeap {
	heap := MinHeap(array)
	ptr := &heap
	ptr.BuildHeap(array)
	return ptr
}

// O(n) time | O(1) space
func (h *MinHeap) BuildHeap(array []int) {
	first := (len(array) - 2) / 2
	for i := first + 1; i >= 0; i-- {
		h.siftDown(i, len(array)-1)
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

// O(log(n)) time | O(1) space
func (h *MinHeap) siftUp() {
	index := h.length() - 1
	parentIndex := (index - 1) / 2
	for index > 0 {
		item, parent := (*h)[index], (*h)[parentIndex]
		if item < parent {
			h.swap(index, parentIndex)
			index = parentIndex
			parentIndex = (index - 1) / 2
		} else {
			return
		}
	}
}

// O(1) time | O(1) space
func (h MinHeap) Peek() int {
	if len(h) == 0 {
		return -1
	}
	return h[0]
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Remove() int {
	l := h.length()
	h.swap(0, l-1)
	peeked := (*h)[l-1]
	*h = (*h)[0 : l-1]
	h.siftDown(0, l-2)
	return peeked
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Insert(value int) {
	*h = append(*h, value)
	h.siftUp()
}

func (h MinHeap) swap(i, j int) {
	h[i], h[j] = h[j], h[i]
}

func (h MinHeap) length() int {
	return len(h)
}
