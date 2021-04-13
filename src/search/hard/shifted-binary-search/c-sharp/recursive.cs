using System;

/*
The Binary Search algorithm involves a left pointer and a right pointer and using those pointers to find the middle number in an array. However we cannot simply find the middle number of the array and compare it to the target here, because the shift could lead the pointer in the wrong direction. 

After defining the middle number in the array, if it is not equal to the target number, the following four scenarios are possible: 
 - the left-pointer number is smaller than or equal to the middle number (so the numbers to the left of our middle are sorted), so two other scenarios can arise: 
    + the target number is smaller than the middle number and greater than or equal to the left-pointer number, so the right half of the array can be eliminated (we stablished the left is sorted so our target should be there) 
    + the target number is not in the left side of the array, so it can be eliminated and we continue searching right
 - the right-pointer number is bigger than or equal to our target, and our target is bigger than the middle number, so we eliminate the left and continue searching right
 - the condition above is not true so our target cannot be on the right side of the array, so we eliminate it and continue searching left

At some point following this algorithm we'll either find the number, or our left and right pointers will cross and we can return -1 since the target is not present in the array, same as with binary search.

Time : O(log(n)) - Where N is the length of the input array
Space: O(log(n)) - For the recursive call stack memory frames
*/
public class Program
{
    public static int ShiftedBinarySearch(int[] array, int target)
    {
        return ShiftedBinarySearch(array, target, 0, array.Length - 1);
    }

    public static int ShiftedBinarySearch(int[] array, int target, int left, int right)
    {
        if (left > right)
        {
            return -1;
        }
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
                    return ShiftedBinarySearch(array, target, left, middle - 1);
                }
                else
                {
                    return ShiftedBinarySearch(array, target, middle + 1, right);
                }
            }
            else
            {
                if (target > match && target <= rightValue)
                {
                    return ShiftedBinarySearch(array, target, middle + 1, right);
                }
                else
                {
                    return ShiftedBinarySearch(array, target, left, middle - 1);
                }
            }
        }
    }
}
