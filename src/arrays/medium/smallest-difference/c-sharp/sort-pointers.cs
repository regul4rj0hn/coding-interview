using System;

/*
To optimize the brute-force approach, start by sorting both arrays. Put a pointer at the beginning of each and evaluate the absolute difference of the first and second numbers. 
If the difference is equal to zero, then that's the closest possible pair; otherwise, increment only the pointer of the smaller of the two numbers to find a potentially better pair. 
Continue with this approach until we find the pair with a difference of zero or until one of the pointers gets out of range of its array.

Time : O(n.log(n) + m.log(m)) - Where N is the length of the first input array and M the length of the second input array (assuming x.log(x) time sort)
Space: O(1)                   - Compare in place, no extra space
*/
public class Program {
    public static int[] SmallestDifference (int[] arrayOne, int[] arrayTwo) {
        int[] output = new int[2];
        int smallest = int.MaxValue;
        int indexOne = 0;
        int indexTwo = 0;

        Array.Sort (arrayOne);
        Array.Sort (arrayTwo);

        while (indexOne < arrayOne.Length && indexTwo < arrayTwo.Length) {
            int first = arrayOne[indexOne];
            int second = arrayTwo[indexTwo];
            int abs = Math.Abs (first - second);

            if (first == second) {
                output = new int[] { first, second };
                break;
            }

            if (first < second) {
                indexOne++;
            }
            else {
                indexTwo++;
            }

            if (abs < smallest) {
                smallest = abs;
                output = new int[] { first, second };
            }
        }

        return output;
    }
}