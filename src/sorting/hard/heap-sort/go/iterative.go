package main

// Best : O(n.log(n)) time | O(1) space
// Avrg : O(n.log(n)) time | O(1) space
// Worst: O(n.log(n)) time | O(1) space
func HeapSort(array []int) []int {
	buildMaxHeap(array)
	for end := len(array) - 1; end >= 1; end-- {
		swap(0, end, array)
		siftDown(0, end-1, array)
	}
	return array
}

func buildMaxHeap(array []int) {
	first := (len(array) - 2) / 2
	for i := first + 1; i >= 0; i-- {
		siftDown(i, len(array)-1, array)
	}
}

func siftDown(idx, end int, heap []int) {
	leftChildIdx := idx*2 + 1
	for leftChildIdx <= end {
		rightChildIdx := -1
		if idx*2+2 <= end {
			rightChildIdx = idx*2 + 2
		}
		toSwap := leftChildIdx
		if rightChildIdx > -1 && heap[rightChildIdx] > heap[leftChildIdx] {
			toSwap = rightChildIdx
		}
		if heap[toSwap] > heap[idx] {
			swap(idx, toSwap, heap)
			idx = toSwap
			leftChildIdx = idx*2 + 1
		} else {
			return
		}
	}
}

func swap(i, j int, array []int) {
	array[i], array[j] = array[j], array[i]
}
