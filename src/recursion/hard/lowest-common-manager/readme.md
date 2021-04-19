# Lowest Common Manager

## Description
You're given three inputs, all of which are instances of an `OrgChart` class that have a `directReports` property pointing to their direct reports. The first input is the top manager in an organizational chart (i.e., the only instance that isn't anybody else's direct report), and the other two inputs are reports in the organizational chart. The two reports are guaranteed to be distinct.

Write a function that returns the lowest common manager to the two reports.

## Sample Input
```
topManager = Node A
reportOne = Node E
reportTwo = Node I

// From the organizational chart below:
          A
       /     \
      B       C
    /   \   /   \
   D     E F     G
 /   \
H     I
```

## Sample Output
```
Node B
```