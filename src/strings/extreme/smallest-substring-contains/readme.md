# Smallest Substring Containing

## Description
You're given two non-empty strings: a big string and a small string. Write a function that returns the smallest substring in the big string that contains all of the small string's characters.

Note that:
- The substring can contain other characters not found in the small string.
- The characters in the substring don't have to be in the same order as they appear in the small string.
- If the small string has duplicate characters, the substring has to contain those duplicate characters (it can also contain more, but not fewer).

You can assume that there will only be one relevant smallest substring.

## Sample Input
```
bigString = "abcd$ef$axb$c$"
smallString = "$$abf"
```

## Sample Output
```
"f$axb$"
````