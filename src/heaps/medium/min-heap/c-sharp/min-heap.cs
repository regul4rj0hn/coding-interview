using System;
using System.Collections.Generic;

/*
 - The heap is a complete binary tree structure
 - Every node's value must be less-than or equal-to their children nodes' values
 - The Sift (Up/Down) operation continiously swaps a node up or down with its parent or children until the node is in the correct position
 - We can achive an easy Min Heap implementation using a List data structure to store the nodes of the binary tree (operations can be done in-place too, so space complexity ~ O(1))
 - The nodes aren't necessarily ordered, but the first value of the heap will always be the smallest node (for a min heap, max heap is the opposite).
 - It's easy to locate the children or parent nodes of a given node on the list (for inserting or removing) using its index as follows:
    - Current Node = i
    - Parent Node = floor((i-1) / 2)
    - Left Child = 2i + 1
    - Right Child = 2i + 2
*/
public class Program {
    public class MinHeap {
        public List<int> heap = new List<int>();

        public MinHeap (List<int> array) {
            heap = buildHeap (array);
        }

        // Start at the very last parent node on the input array
        // Call the sift down method consecutively on every parent node
        // Note that it won't necessary yield a sorted array, just a valid Heap
        // Can also be implemented by consecutively shifting children up the heap, but it is less optimal
        // Sift down converges to O(n) because it is only run on parent nodes: 
        //  - The bottom row of parents will only be swapped at most once (so constant time)
        //  - The one that takes the longest to sift down is the root, which will at most will be swapped down N levels
        // O(n) time | O(1) space
        public List<int> buildHeap (List<int> array) {
            var firstParentIdx = (array.Count - 2) / 2;
            for (int i = firstParentIdx; i >= 0; i--) {
                siftDown (i, array.Count - 1, array);
            }
            return array;
        }

        // The root node always holds the minimum value in a MinHeap
        public int Peek () {
            return heap[0];
        }

        // Removes the root node by first swapping it with the last node of the heap
        // Once the swap is done we remove the last node (our previous root) to keep the heap complete
        // Sift the new root node down with its smallest children, until we find it's correct position to keep the heap valid (min property)
        public int Remove () {
            Swap (0, heap.Count - 1, heap);
            var toRemove = heap[heap.Count - 1];
            heap.RemoveAt (heap.Count - 1);
            siftDown (0, heap.Count - 1, heap);
            return toRemove;
        }

        // Insert at the end of the list to satisfy the complete property of the heap
        // Sift the inserted node up until we find it's correct position
        public void Insert (int value) {
            heap.Add (value);
            siftUp (heap.Count - 1, heap);
        }

        // O(log(n)) time | O(1) space
        private void siftDown (int currentIdx, int endIdx, List<int> heap) {
            var childOneIdx = currentIdx * 2 + 1;
            
            while (childOneIdx <= endIdx) {
                var rightIdx = currentIdx * 2 + 2;
                var childTwoIdx =  rightIdx <= endIdx ? rightIdx : -1;
                var toSwap = childTwoIdx != -1 && heap[childTwoIdx] < heap[childOneIdx] ? childTwoIdx : childOneIdx;
                
                if (heap[toSwap] < heap[currentIdx]) {
                    Swap (currentIdx, toSwap, heap);
                    currentIdx = toSwap;
                    childOneIdx = currentIdx * 2 + 1;
                }
                else {
                    return;
                }
            }
        }

        // O(log(n)) time | O(1) space
        private void siftUp (int currentIdx, List<int> heap) {
            var parentIdx = (currentIdx - 1) / 2;
            while (currentIdx > 0 && heap[currentIdx] < heap[parentIdx]) {
                Swap (currentIdx, parentIdx, heap);
                currentIdx = parentIdx;
                parentIdx = (currentIdx - 1) / 2;
            }
        }

        // Exchange the position of the node at index i with the one at index j
        private void Swap (int i, int j, List<int> heap) {
            int tmp = heap[j];
            heap[j] = heap[i];
            heap[i] = tmp;
        }
    }
}
