using System;

/*
The iterative approach is the same as the recursive approach, but has improved (constant) space complexity since we avoid the recursive call frames.

Time : O(log(n)) - Where N is the length of the input array
Space: O(1)      - The iterative solution does not require extra space
*/
public class Program
{
    public static int ShiftedBinarySearch(int[] array, int target)
    {
        return ShiftedBinarySearch(array, target, 0, array.Length - 1);
    }

    public static int ShiftedBinarySearch(int[] array, int target, int left, int right)
    {
        while (left <= right)
        {
            var middle = (left + right) / 2;
            var match = array[middle];
            var leftValue = array[left];
            var rightValue = array[right];

            if (target == match)
            {
                return middle;
            }
            else
            {
                if (leftValue <= match)
                {
                    if (target < match && target >= leftValue)
                    {
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                else
                {
                    if (target > match && target <= rightValue)
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }
            }
        }
        return -1;
    }
}
