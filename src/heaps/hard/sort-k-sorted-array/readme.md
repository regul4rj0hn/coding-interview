# Sort K-Sorted Array

## Description
Write a function that takes in a non-negative integer K and a K-sorted array of integers and returns the sorted version of the array. Your function can either sort the array in place or create an entirely new array.

A K-sorted array is a partially sorted array in which all elements are at most K positions away from their sorted position. For example, the array `[3, 1, 2, 2]` is K-sorted with `k = 2`, because each element in the array is at most 2 positions away from its sorted position.

Note that you're expected to come up with an algorithm that can sort the K-sorted array faster than in O(nlog(n)) time.

## Sample Input
```
array = [3, 2, 1, 5, 4, 7, 6, 5]
k = 3
```

## Sample Output
```
[1, 2, 3, 4, 5, 5, 6, 7]
```