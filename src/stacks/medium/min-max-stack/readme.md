# Min-Max Stack Construction

## Description
Write a `MinMaxStack` class for a Min-Max Stack. The class should support:
- Pushing and popping values on and off the stack.
- Peeking at the value at the top of the stack.
- Getting both the minimum and the maximum values in the stack at any given point in time.

All class methods, when considered independently, should run in constant time and with constant space.

## Sample Usage
```
// All operations below are performed sequentially.
MinMaxStack(): - // instantiate a MinMaxStack
push(5): -
getMin(): 5
getMax(): 5
peek(): 5
push(7): -
getMin(): 5
getMax(): 7
peek(): 7
push(3): -
getMin(): 3
getMax(): 7
peek(): 3
pop(): 3
pop(): 7
getMin(): 5
getMax(): 5
peek(): 5
```
