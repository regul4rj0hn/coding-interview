# Monotonic Array

## Description
Write a function that takes in an array of integers and returns a boolean representing whether the array is monotonic.

An array is said to be monotonic if one of the following rules is true:
- It's empty
- It's got one element
- Its elements, from left to right, are entirely non-increasing or entirely non-decreasing.

Note that non-increasing elements aren't necessarily exclusively decreasing; they simply don't increase. Similarly, non-decreasing elements aren't necessarily exclusively increasing; they simply don't decrease.

## Sample Input
```
array = [-1, -5, -10, -1100, -1100, -1101, -1102, -9001]
```

## Sample Output
```
true
```