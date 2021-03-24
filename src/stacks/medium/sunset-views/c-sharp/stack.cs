using System.Collections.Generic;
using System;

/*
Basic strategy is to determine whether we need to loop the building heights array forward (west) or backwards (east) depending on the direction that the buildings are facing.

We keep a stack of building heights and their position. Loop through the array of buildings and if the current building is taller than the top of our stack, we add it to the the stack. At the end of the process the stack will contain all the buildings that can see the sunset.

For the East case the items will be stacked backwards, so we need to pop the buildings that can see the sunset and add their indeces to our output list.

Time : O(n) - Where N is the length of the input building array.
Space: O(n) - For the output list of buildings that can view the sunset (worst case all buildings can)
*/
public class Program {
    private const string East = "EAST";
    private const string West = "WEST";

    public List<int> SunsetViews (int[] buildings, string direction) {
        var output = new List<int> ();

        if (direction == East) {
            CheckEastBuildings (buildings, output);
        }

        if (direction == West) {
            CheckWestBuildings (buildings, output);
        }

        return output;
    }

    private void CheckEastBuildings (int[] buildings, List<int> output) {
        var indexes = new Stack<KeyValuePair<int,int>> ();

        for (int i = buildings.Length - 1; i >= 0; i--) {
            if (indexes.Count == 0 || buildings[i] > indexes.Peek().Value) {
                indexes.Push (new KeyValuePair<int, int> (i, buildings[i]));
            }
        }

        while (!(indexes.Count == 0)) {
            var index = indexes.Pop ();
            output.Add (index.Key);
        }
    }
    
    private void CheckWestBuildings (int[] buildings, List<int> output) {
        var indexes = new Stack<KeyValuePair<int,int>> ();

        for (int i = 0; i < buildings.Length; i++) {
            if (indexes.Count == 0 || buildings[i] > indexes.Peek().Value) {
                indexes.Push (new KeyValuePair<int, int>(i, buildings[i]));
                output.Add (i);
            }
        }
    }
}
