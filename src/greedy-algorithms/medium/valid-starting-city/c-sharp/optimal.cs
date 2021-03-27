using System;

/*
Using the fact that the total amount of fuel is exactly enough to travel around the road once, and the knowledge that there is always only one valid starting city, the problem can be resolved in a single pass. 

Keep track of how much fuel you have as you enter a city (before filling up at that city); enter the first city with 0 remining miles (can't move without fueling up).

The city that we enter with the least amount of fuel in our tank must be the valid starting city. This is because we'll never have less fuel at another city than you do when you enter the correct city, no matter which city you start at.

Time : O(n) - Where N is the number of cities
Space: O(1) - Calculations done in place
*/
public class Program
{
    public int ValidStartingCity (int[] distances, int[] fuel, int mpg)
    {
        var miles = 0;
        var startingCity = 0;
        var milesRemaining = 0;

        for (int city = 1; city < distances.Length; city++)
        {
            miles += fuel[city - 1] * mpg - distances[city - 1];

            if (miles < milesRemaining)
            {
                milesRemaining = miles;
                startingCity = city;
            }
        }

        return startingCity;
    }
}
