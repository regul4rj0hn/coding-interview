using System;

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