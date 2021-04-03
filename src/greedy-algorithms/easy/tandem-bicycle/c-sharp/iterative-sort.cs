using System;

/*
The general approach is to sort the red and blue shirts rider speeds, and pair them depending on whether fastest is true or false:
 - If we want the maximum possible total speed we need to pair the fastest riders from one group with the slowest from the other grup, as the speed is always Max(red, blue)
 - If we want the minimum total speed, we need to pair the slowest riders together, and the fastest riders together which results in the minimum total speed

We calculate the total speed to return as we loop through the speed arrays and pair the bike riders together, so there's no need to keep track of the pairs.

Time : O(n.log(n)) - Where N is the length of the input arrays and assuming optimal sort time complexity 
Space: O(1)        - No extra space used, sort in place
*/
public class Program {
    public int TandemBicycle (int[] redShirtSpeeds, int[] blueShirtSpeeds, bool fastest) {
        Array.Sort (redShirtSpeeds);
        Array.Sort (blueShirtSpeeds);

        var totalSpeed = 0;
        var redRider = fastest ? redShirtSpeeds.Length - 1 : 0;
        var step = fastest ? -1 : 1;

        for (var blueRider = 0; blueRider < blueShirtSpeeds.Length; blueRider++) {
            totalSpeed += Math.Max (redShirtSpeeds[redRider], blueShirtSpeeds[blueRider]);
            redRider += step;
        }

        return totalSpeed;
    }
}
