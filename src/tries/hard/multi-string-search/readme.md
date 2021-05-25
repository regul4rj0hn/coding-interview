# Multi-String Search

## Description
Write a function that takes in a big string and an array of small strings, all of which are smaller in length than the big string. The function should return an array of booleans, where each boolean represents whether the small string at that index in the array of small strings is contained in the big string.

Note that you can't use language-built-in string-matching methods.

## Sample Input #1
```
bigString    = "this is a big string"
smallStrings = ["this", "yo", "is", "a", "bigger", "string", "kappa"]
```

## Sample Output #1
```
[true, false, true, true, false, true, false]
```

## Sample Input #2
```
bigString    = "abcdefghijklmnopqrstuvwxyz"
smallStrings = ["abc", "mnopqr", "wyz", "no", "e", "tuuv"]
```

## Sample Output #2
```
[true, true, false, true, true, false]
```