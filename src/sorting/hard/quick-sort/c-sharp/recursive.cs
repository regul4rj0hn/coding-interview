using System;

/*
Quick Sort works by picking a "pivot" number from an array, positioning every other number in the array in sorted order with respect to the pivot (all smaller numbers to the pivot's left; all bigger numbers to the pivot's right), and then repeating the same two steps on both sides of the pivot until the entire array is sorted.

Pick a random number from the input array, e.g. the first number, and let that number be the pivot. Iterate through the rest of the array using two pointers, one starting at the left extremity of the array and progressively moving to the right, and the other one starting at the right extremity of the array and progressively moving to the left. As you iterate through the array, compare the left and right pointer numbers to the pivot:
 - If the left number is greater than the pivot and the right number is less than the pivot, swap them; this will effectively sort these numbers with respect to the pivot at the end of the iteration.
 - If the left number is ever less than or equal to the pivot, increment the left pointer; 
 - Similarly, if the right number is ever greater than or equal to the pivot, decrement the right pointer.
Do this until the pointers pass each other, at which point swapping the pivot with the right number should position the pivot in its final, sorted position, where every number to its left is smaller and every number to its right is greater.
Then repeat the process on the respective subarrays located to the left and right of our pivot, and keep on repeating the process thereafter until the input array is fully sorted.

Best   : O(n.log(n)) time | O(log(n)) space
Average: O(n.log(n)) time | O(log(n)) space
Worst  : O(n^2)      time | O(log(n)) space
*/
public class Program
{
    public static int[] QuickSort(int[] array)
    {
        Quicksort(array, 0, array.Length - 1);
        return array;
    }

    private static void Quicksort(int[] array, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        var pivot = start;
        var left = start + 1;
        var right = end;
        while (right >= left)
        {
            if (array[left] > array[pivot] && array[right] < array[pivot])
            {
                Swap(left, right, array);
            }
            if (array[left] <= array[pivot])
            {
                left++;
            }
            if (array[right] >= array[pivot])
            {
                right--;
            }
        }
        Swap(pivot, right, array);

        var isLeftSubarraySmaller = right - 1 - start < end - (right + 1);
        if (isLeftSubarraySmaller)
        {
            Quicksort(array, start, right - 1);
            Quicksort(array, right + 1, end);
        }
        else
        {
            Quicksort(array, right + 1, end);
            Quicksort(array, start, right - 1);
        }
    }

    private static void Swap(int i, int j, int[] array)
    {
        int tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
}
