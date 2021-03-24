using System.Collections.Generic;
using System;

/*
While the time and space complexity are the same, this clean-up of the Stack implementation might use less memory:
 - Parametrize the direction in which we need to traverse the buildings array (West = forward, East = Backwards)
 - Get rid of the stack structure as we only care about the last tallest building
 - Whenever we find a building that's strickly taller than our previous max height, insert the index for that building's height to the output list and update our max height value
 - If the direction was EAST (we traversed the buildings array backwards), just reverse the output array with the built-in O(n) method so that the output is in the required order

Time : O(n) - Where N is the length of the input building array.
Space: O(n) - For the output list of buildings that can view the sunset (worst case all buildings can)
*/
public class Program
{
    private const string East = "EAST";
    private const string West = "WEST";

    public List<int> SunsetViews(int[] buildings, string direction)
    {
        var output = new List<int>();

        int index = direction == East ? buildings.Length - 1 : 0;
        int step = direction == East ? -1 : 1;
        int maxHeight = 0;

        while (index >= 0 && index < buildings.Length)
        {
            var height = buildings[index];

            if (height > maxHeight)
            {
                output.Add (index);
                maxHeight = height;
            }

            index += step;
        }

        if (direction == East)
        {
            output.Reverse();
        }

        return output;
    }
}
