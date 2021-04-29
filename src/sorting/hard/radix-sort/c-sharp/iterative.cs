using System.Collections.Generic;
using System.Linq;
using System;

/*
Radix Sort sorts numbers by looking only at one of their digits at a time. It first sorts all of the given numbers by their ones' column, then by their tens' column, then by their hundreds' column, and so on and so forth until they're fully sorted.

It uses an intermediary sorting algorithm that runs multiple times to sort numbers one digits' column at a time. The goal of Radix Sort is to perform a more efficient sort than popular sorting algorithms like Merge Sort or Quick Sort for inputs that are well suited to be sorted by their individual digits' columns.

The most popular sorting algorithm to use with Radix Sort is Counting Sort. It takes advantage of the fact that we know the range of possible values that we need to sort. When sorting numbers, we know that we only need to sort digits, which will always be in the range 0-9. Therefore, we can count how many times these digits occur and use those counts to populate a new sorted array. We'll perform counting sort multiple times, once for each digits' column that we're sorting, starting with the ones' column. We need to ensure that our counting sort performs a stable sort, so that we don't lose information from previous iterations of sorting. Counting sort runs in O(n) time, which means that we might have a much more efficient sorting algorithm if the largest number in our input contains few digits.

Time : O(d.(n+b)) - Where N is the length of the input array, D is the maximum number of digits, and B is the base of the numbering system used (10)
Space: O(n+b)     - To store the intermediate data structures on CountingSort
*/
public class Program
{
    public List<int> RadixSort(List<int> array)
    {
        if (array.Count == 0)
        {
            return array;
        }
        var max = array.Max();
        var digit = 0;
        while ((max / Math.Pow(10, digit)) > 0)
        {
            CountingSort(array, digit);
            digit++;
        }
        return array;
    }

    private void CountingSort(List<int> array, int digit)
    {
        var sorted = new int[array.Count];
        var count = new int[10];
        var column = (int)Math.Pow(10, digit);

        foreach (var num in array)
        {
            var countIndex = (num / column) % 10;
            count[countIndex] += 1;
        }

        for (var i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        for (var i = array.Count - 1; i > -1; i--)
        {
            var countIndex = (array[i] / column) % 10;
            count[countIndex] -= 1;
            var sortedIndex = count[countIndex];
            sorted[sortedIndex] = array[i];
        }

        for (var i = 0; i < array.Count; i++)
        {
            array[i] = sorted[i];
        }
    }
}
