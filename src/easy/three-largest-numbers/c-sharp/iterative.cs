using System;

/* Kind of dirty and uses Sort on the solution array (3 elements) */
public class Program {
    public static int[] FindThreeLargestNumbers (int[] array) {
        var ret = new int[] { array[0], array[1], array[2] };
        Array.Sort (ret);

        for (int i = 3; i < array.Length; i++) {
            int current = array[i];
            if (current > ret[0]) {
                if (current > ret[1]) {
                    if (current > ret[2]) {
                        ret[0] = ret[1];
                        ret[1] = ret[2];
                        ret[2] = current;
                    }
                    else {
                        ret[0] = ret[1];
                        ret[1] = current;
                    }
                }
                else {
                    ret[0] = current;
                }
            }
        }

        return ret;
    }
}