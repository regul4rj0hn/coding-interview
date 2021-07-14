package main

import (
	"sort"
)

// O(n.log(n)) time | O(n) space
// where N is the number of times on the input array
func LaptopRentals(times [][]int) int {
	if len(times) == 0 {
		return 0
	}

	sort.Slice(times, func(i, j int) bool {
		return times[i][0] < times[j][0]
	})

	laptopUsed := [][]int{times[0]}
	heap := NewMinHeap(laptopUsed)

	for i := 1; i < len(times); i++ {
		interval := times[i]
		if heap.Peek()[1] <= interval[0] {
			heap.Remove()
		}
		heap.Insert(interval)
	}

	return heap.Length()
}

// Min Heap
type MinHeap [][]int

func NewMinHeap(array [][]int) *MinHeap {
	heap := MinHeap(array)
	ptr := &heap
	ptr.buildHeap(array)
	return ptr
}

func (h *MinHeap) IsEmpty() bool {
	return len(*h) == 0
}

func (h *MinHeap) Length() int {
	return len(*h)
}

func (h *MinHeap) Peek() []int {
	return (*h)[0]
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Remove() []int {
	h.swap(0, h.Length()-1)
	last := (*h)[h.Length()-1]
	(*h) = (*h)[:h.Length()-1]
	h.siftDown(0, h.Length()-1)
	return last
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Insert(value []int) {
	*h = append(*h, value)
	h.siftUp(h.Length() - 1)
}

// O(log(n)) time | O(1) space
func (h *MinHeap) siftUp(index int) {
	parentIndex := (index - 1) / 2
	for index > 0 && (*h)[index][1] < (*h)[parentIndex][1] {
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
		if rightChildIdx != -1 && (*h)[rightChildIdx][1] < (*h)[leftChildIdx][1] {
			indexToSwap = rightChildIdx
		}

		if (*h)[indexToSwap][1] < (*h)[start][1] {
			h.swap(start, indexToSwap)
			start = indexToSwap
			leftChildIdx = start*2 + 1
		} else {
			return
		}
	}
}

// O(n) time | O(1) space
func (h *MinHeap) buildHeap(array [][]int) {
	first := (len(array) - 2) / 2
	for index := first; index >= 0; index-- {
		h.siftDown(index, len(array)-1)
	}
}

func (h *MinHeap) swap(i, j int) {
	(*h)[i], (*h)[j] = (*h)[j], (*h)[i]
}
