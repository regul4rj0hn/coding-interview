package main

type Item struct {
	ArrayIdx   int
	ElementIdx int
	Value      int
}

func MergeSortedArrays(arrays [][]int) []int {
	sortedList := []int{}
	smallestItems := []Item{}

	for i := 0; i < len(arrays); i++ {
		smallestItems = append(smallestItems, Item{
			ArrayIdx:   i,
			ElementIdx: 0,
			Value:      arrays[i][0],
		})
	}

	mh := NewMinHeap(smallestItems)
	for mh.length() != 0 {
		smallestItem := mh.Remove()
		sortedList = append(sortedList, smallestItem.Value)
		if smallestItem.ElementIdx == len(arrays[smallestItem.ArrayIdx])-1 {
			continue
		}
		mh.Insert(Item{
			ArrayIdx:   smallestItem.ArrayIdx,
			ElementIdx: smallestItem.ElementIdx + 1,
			Value:      arrays[smallestItem.ArrayIdx][smallestItem.ElementIdx+1],
		})
	}

	return sortedList
}

type MinHeap []Item

func NewMinHeap(array []Item) *MinHeap {
	heap := MinHeap(array)
	ptr := &heap
	ptr.BuildHeap(array)
	return ptr
}

// O(n) time | O(1) space
func (h *MinHeap) BuildHeap(array []Item) {
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
		if rightChildIdx > -1 && (*h)[rightChildIdx].Value < (*h)[leftChildIdx].Value {
			toSwap = rightChildIdx
		}
		if (*h)[toSwap].Value < (*h)[start].Value {
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
	startIdx := h.length() - 1
	parentIdx := (startIdx - 1) / 2
	for startIdx > 0 {
		start, parent := (*h)[startIdx].Value, (*h)[parentIdx].Value
		if start < parent {
			h.swap(startIdx, parentIdx)
			startIdx = parentIdx
			parentIdx = (startIdx - 1) / 2
		} else {
			return
		}
	}
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Remove() Item {
	l := h.length()
	h.swap(0, l-1)
	peeked := (*h)[l-1]
	*h = (*h)[0 : l-1]
	h.siftDown(0, l-2)
	return peeked
}

// O(log(n)) time | O(1) space
func (h *MinHeap) Insert(value Item) {
	*h = append(*h, value)
	h.siftUp()
}

func (h MinHeap) swap(i, j int) {
	h[i], h[j] = h[j], h[i]
}

func (h MinHeap) length() int {
	return len(h)
}
