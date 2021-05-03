using System;

/*
The heapsort algorithm can be implemented with either a min heap or a max heap and is divided into two parts. 

In the first step, we build heap out of the data. The heap is placed in an array with the layout of a complete binary tree. The complete binary tree maps the binary tree structure into the array indices; each array index represents a node; the index of the node's parent, left child branch, or right child branch are simple expressions. For a zero-based array, the root node is stored at index 0; if i is the index of the current node, then:
  iParent(i)     = floor((i-1) / 2) where floor functions map a real number to the smallest leading integer.
  iLeftChild(i)  = 2*i + 1
  iRightChild(i) = 2*i + 2

In the second step, a sorted array is created by repeatedly removing the largest element from the heap (the root of the heap), and inserting it into the array. We update the heap after each removal to maintain the heap property. Once all objects have been removed from the heap, the result is a sorted array. 

Time : O(n.log(n)) - Where N is the length of the input array
Space: O(1)        - Heapsort is performed in place. The array is split into two parts, the sorted array and the heap. The heap's invariant is preserved after each extraction, so the only cost is that of extraction.
*/
public class Program {
    public static int[] HeapSort(int[] array) {
        BuildMaxHeap (array);

        for (int i = array.Length - 1; i > 0; i--){
            Swap (0, i , array);
            SiftDown (0, i - 1, array);
        }
        return array;
    }

    private static void BuildMaxHeap (int[] array) {
        var firstParentIdx = (array.Length - 2) / 2;
        for (var current = firstParentIdx; current >= 0; current--) {
            SiftDown (current, array.Length - 1, array);
        }
    }

    private static void SiftDown (int current, int end, int[] heap) {
        var leftChild = current * 2 + 1;
        while (leftChild <= end) {
            var rightChild = current * 2 + 2 <= end ? current * 2 + 2 : -1;
            var toSwap = rightChild != -1 && heap[rightChild] > heap[leftChild] ? rightChild : leftChild;

            if (heap[toSwap] < heap[current]) {
                return;
            }
            Swap (current, toSwap, heap);
            current = toSwap;
            leftChild = current * 2 + 1;
        }
    }

    private static void Swap (int i, int j, int[] array) {
        int tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
}