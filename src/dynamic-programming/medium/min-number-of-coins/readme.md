# Minimum Number of Coins for Change

## Description
Given an array of positive integers representing coin denominations and a single non-negative integer `n` representing a target amount of money, write a function that returns the smallest number of coins needed to make change for (to sum up to) that target amount using the given coin denominations.

Note that you have access to an unlimited amount of coins. In other words, if the denominations are `[1, 5, 10]`, you have access to an unlimited amount of `1`s, `5`s, and `10`s.

If it's impossible to make change for the target amount, return `-1`.

## Sample Input
```
n = 7
denoms = [1, 5, 10]
```

## Sample Output
```
3 // 2x1 + 1x5
```