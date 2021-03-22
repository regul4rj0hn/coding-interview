using System;

/*
The approach / algorithm is the same as with the two-loops, only that with a single pass through the array, we have to implement the strategy all at once.
The implementation combined with the strategy on the two-loops solution shouold be self-explanatory.

Time : O(n) - Where N is the length of the input array that we need to sort
Space: O(1) - No extra space used, sort in place
*/
public class Program
{
    public int[] ThreeNumberSort (int[] array, int[] order)
    {
        var firstOrder = order[0];
        var secondOrder = order[1];

        var firstIdx = 0;
        var secondIdx = 0;
        var thirdIdx = array.Length - 1;

        while (secondIdx <= thirdIdx)
        {
            var current = array[secondIdx];

            if (current == firstOrder)
            {
                Swap (firstIdx, secondIdx, array);
                firstIdx++;
                secondIdx++;
            }
            else
            {
                if (current == secondOrder)
                {
                    secondIdx++;
                }
                else
                {
                    Swap (secondIdx, thirdIdx, array);
                    thirdIdx--;
                }
            }
        }

        return array;
    }

    private void Swap (int i, int j, int[] array)
    {
        var tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
}