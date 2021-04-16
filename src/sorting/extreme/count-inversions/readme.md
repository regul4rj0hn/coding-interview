# Count Inversions

## Description
Write a function that takes in an array of integers and returns the number of inversions in the array. An inversion occurs if for any valid indices `i` and `j`, `i < j` and `array[i] > array[j]`.

For example, given `array = [3, 4, 1, 2]`, there are `4` inversions. The following pairs of indices represent inversions: `[0, 2], [0, 3], [1, 2], [1, 3]`.

Intuitively, the number of inversions is a measure of how unsorted the array is.

## Sample Input
```
array = [2, 3, 3, 1, 9, 5, 6]
```

## Sample Output
```
5
// The following pairs of indices represent inversions:
// [0, 3], [1, 3], [2, 3], [4, 5], [4, 6]
```