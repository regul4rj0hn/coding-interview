package main

type ContinuousMedianHandler struct {
	Median  float64
	lower   *Heap
	greater *Heap
}

func NewContinuousMedianHandler() *ContinuousMedianHandler {
	return &ContinuousMedianHandler{
		Median:  0,
		lower:   NewHeap(MaxHeapFunc),
		greater: NewHeap(MinHeapFunc),
	}
}

func (handler *ContinuousMedianHandler) GetMedian() float64 {
	return handler.Median
}

// O(log(n)) time | O(n) space
func (handler *ContinuousMedianHandler) Insert(number int) {
	if handler.lower.Length() == 0 || number < handler.lower.Peek() {
		handler.lower.Insert(number)
	} else {
		handler.greater.Insert(number)
	}
	handler.rebalanceHeaps()
	handler.updateMedian()
}

func (handler *ContinuousMedianHandler) rebalanceHeaps() {
	if handler.lower.Length()-handler.greater.Length() == 2 {
		handler.greater.Insert(handler.lower.Remove())
	} else if handler.greater.Length()-handler.lower.Length() == 2 {
		handler.lower.Insert(handler.greater.Remove())
	}
}

func (handler *ContinuousMedianHandler) updateMedian() {
	if handler.lower.Length() == handler.greater.Length() {
		sum := (handler.lower.Peek() + handler.greater.Peek())
		handler.Median = float64(sum) / 2
	} else if handler.lower.Length() > handler.greater.Length() {
		handler.Median = float64(handler.lower.Peek())
	} else {
		handler.Median = float64(handler.greater.Peek())
	}
}

type Heap struct {
	compare HeapFunc
	values  []int
}

type HeapFunc func(int, int) bool

var MinHeapFunc = func(a, b int) bool { return a < b }
var MaxHeapFunc = func(a, b int) bool { return a > b }

func NewHeap(fn HeapFunc) *Heap {
	return &Heap{
		compare: fn,
		values:  []int{},
	}
}

func (h *Heap) Length() int {
	return len(h.values)
}

func (h *Heap) Peek() int {
	if len(h.values) == 0 {
		return -1
	}
	return h.values[0]
}

func (h *Heap) Insert(value int) {
	h.values = append(h.values, value)
	h.siftUp()
}

func (h *Heap) Remove() int {
	l := h.Length()
	h.swap(0, l-1)
	peek := h.values[l-1]
	h.values = h.values[0 : l-1]
	h.siftDown()
	return peek
}

func (h *Heap) siftUp() {
	currentIndex := h.Length() - 1
	parentIndex := (currentIndex - 1) / 2
	for currentIndex > 0 {
		current, parent := h.values[currentIndex], h.values[parentIndex]
		if h.compare(current, parent) {
			h.swap(currentIndex, parentIndex)
			currentIndex = parentIndex
			parentIndex = (currentIndex - 1) / 2
		} else {
			return
		}
	}
}

func (h *Heap) siftDown() {
	current := 0
	end := h.Length() - 1
	leftChild := current*2 + 1
	for leftChild <= end {
		rightChild := -1
		if current*2+2 <= end {
			rightChild = current*2 + 2
		}
		toSwap := leftChild
		if rightChild > -1 && h.compare(h.values[rightChild], h.values[leftChild]) {
			toSwap = rightChild
		}
		if h.compare(h.values[toSwap], h.values[current]) {
			h.swap(current, toSwap)
			current = toSwap
			leftChild = current*2 + 1
		} else {
			return
		}
	}
}

func (h *Heap) swap(i, j int) {
	h.values[i], h.values[j] = h.values[j], h.values[i]
}
