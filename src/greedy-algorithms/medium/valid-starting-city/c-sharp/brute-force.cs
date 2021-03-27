using System;

/*
The brute-force approach is quite straight forward, just treat each city like a candidate starting city and see if you have enough fuel to make your way around all cities.
Iterrupt the process as soon as you run out of fuel, or if you've returned back to the starting city.

According to the problem definition, if we assume valid input you should always find a starting city which works - the return -1 should never be hit.

Time : O(n^2) - Where N is the number of cities
Space: O(1)   - Calculations done in place
*/
public class Program {

    public int ValidStartingCity(int[] distances, int[] fuel, int mpg) {
        var cityCount = distances.Length;

        for (var startingCity = 0; startingCity < cityCount; startingCity++) {
            var miles = 0;
            var next = 0;
            var currentTrip = (startingCity + next) % cityCount;
            var backToStartingCity = false;

            while (miles >= 0 && !backToStartingCity) {
                miles += fuel[currentTrip] * mpg;
                miles -= distances[currentTrip];
                next++;
                currentTrip = (startingCity + next) % cityCount;
                backToStartingCity = next % cityCount == 0;
            }

            if (backToStartingCity) {
                return startingCity;
            }
        }

        return -1;
    }
}
