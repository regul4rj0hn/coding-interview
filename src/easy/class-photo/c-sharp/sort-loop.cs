using System;
using System.Collections.Generic;

/*
Time : O(n.log(n)) - Where N is the length of the input list (needs sorting)
Space: O(1)        - Just comparing elements no extra space
*/
public class Program {

    public bool ClassPhotos (List<int> redShirtHeights, List<int> blueShirtHeights) {
        if (redShirtHeights.Count != blueShirtHeights.Count) {
            return false;
        }

        redShirtHeights.Sort ();
        blueShirtHeights.Sort ();

        string firstRow = redShirtHeights[0] < blueShirtHeights[0] ? "RED" : "BLUE";

        for (int i = 0; i < redShirtHeights.Count; i++) {
            if (firstRow == "RED") {
                if (redShirtHeights[i] >= blueShirtHeights[i]) {
                    return false;
                }
            }
            else {
                if (blueShirtHeights[i] >= redShirtHeights[i]) {
                    return false;
                }
            }
        }

        return true;
    }
}