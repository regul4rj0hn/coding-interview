using System;
using System.Collections.Generic;

/* 
Consider that we only need to look at K elements to the left and to the right of the current index to find which element goes in that index. If we traverse from left to right, the elements to the left of the current possition should already be sorted when we arrive there, so we only need to look at the minimum of K+1 elements around the current index to find which element goes there (final position).

If we where to find the minimum among K+1 elements for almost all subsets in the array, that would lead us to a non-optimal time complexity solution. To work around that we use a min-heap as we iterate through the array to keep track of the most recent K elements. On each iteration, we remove the minimum value from the heap, insert it into its final sorted position in the array - which will overwrite an element we don't care about as it is already on our heap, and add the current element in the array to the heap. We continue this process until we get to the end of the array, then we empty up the heap repeating the same process which should result in our sorted array to return.

Obviously inserting an removing elements from the heap adds the time complexity of log(k) (assuming K <= N) since our heap will have at most K+1 elements at any given time, but we are only iterating once through the whole array and sorting it in place (it's actually N*log(K)+K but we get rid of the constants for big-O notation).

Time : O(n.log(k)) - Where N is the number of elements in the input array and K is how far away the elements are from their sorted position
Space: O(k)        - To store the K sorted MinHeap elements
*/
public class Program {
    public int[] SortKSortedArray(int[] array, int k) {
        var heapValues = new List<int>();

        for (var i = 0; i < Math.Min(k + 1, array.Length); i++) {
            heapValues.Add(array[i]);
        }

        var kMinHeap = new MinHeap (heapValues);
        var nextToInsert = 0;
        for (var i = k + 1; i < array.Length; i++) {
            var min = kMinHeap.Remove();
            array[nextToInsert] = min;
            nextToInsert++;
            var current = array[i];
            kMinHeap.Insert(current);
        }

        while (!kMinHeap.IsEmpty()) {
            var min = kMinHeap.Remove();
            array[nextToInsert] = min;
            nextToInsert++;
        }

        return array;
    }

    // Min Heap implementation used in the solution
    public class MinHeap {
        public List<int> heap = new List<int>();

        public MinHeap(List<int> array) {
            heap = buildHeap(array);
        }

        // O(n) time | O(1) space
        public List<int> buildHeap(List<int> array) {
            var firstParentIdx = (array.Count - 2) / 2;
            for (int i = firstParentIdx; i >= 0; i--) {
                siftDown(i, array.Count - 1, array);
            }
            return array;
        }

        // O(log(n)) time | O(1) space
        public void siftDown(int currentIdx, int endIdx, List<int> heap) {
            var childOneIdx = currentIdx * 2 + 1;

            while (childOneIdx <= endIdx) {
                var rightIdx = currentIdx * 2 + 2;
                var childTwoIdx =  rightIdx <= endIdx ? rightIdx : -1;
                var toSwap = childTwoIdx != -1 && heap[childTwoIdx] < heap[childOneIdx] ? childTwoIdx : childOneIdx;

                if (heap[toSwap] < heap[currentIdx]) {
                    Swap(currentIdx, toSwap, heap);
                    currentIdx = toSwap;
                    childOneIdx = currentIdx * 2 + 1;
                }
                else {
                    return;
                }
            }
        }

        // O(log(n)) time | O(1) space
        public void siftUp(int currentIdx, List<int> heap) {
            var parentIdx = (currentIdx - 1) / 2;
            while (currentIdx > 0 && heap[currentIdx] < heap[parentIdx]) {
                Swap(currentIdx, parentIdx, heap);
                currentIdx = parentIdx;
                parentIdx = (currentIdx - 1) / 2;
            }
        }

        public int Peek() {
            return heap[0];
        }

        public int Remove() {
            Swap(0, heap.Count - 1, heap);
            var toRemove = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            siftDown(0, heap.Count - 1, heap);
            return toRemove;
        }

        public void Insert(int value) {
            heap.Add(value);
            siftUp(heap.Count - 1, heap);
        }

        public bool IsEmpty() {
            return heap.Count == 0;
        }

        private void Swap(int i, int j, List<int> heap) {
            int tmp = heap[j];
            heap[j] = heap[i];
            heap[i] = tmp;
        }
    }
}
