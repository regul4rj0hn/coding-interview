using System;

/*
While this approach has time complexity of O(N), it doesn't take into account any of the helpful facts that are given in the problem definition.
That said the solution is the most generic as it would work even if the order array had more than 3 elements. 

We keep track of the last swapped possition, and on each pass through the input array comparing each array element with the current target order value.
After a full iteration of the inner loop, all the target order values will be in their final position. 
A small optimization is to start with the next order target where we left off (last swapped position).

A different approach that takes advantage of the fact that we know the contents of the input array - that is, the three elements on the order array -  is to count how many ocurrences of the items in there order array there are in the array we want to sort. This gets rid of the nested loop, but probably uses more memory. Once we have the amount of X=t, Y=u, Z=v present in the array to sort, we just rewrite our input array with t times the X value, u times with the Y value, and v times with Z.

Time : O(n) - Where N is the length of the input array, it would be N*M but we know the order array has a constant length of 3, so 3N => O(n)
Space: O(1) - No extra space used, sort in place
*/
public class Program {
    public int[] ThreeNumberSort (int[] array, int[] order) {
        var pos = 0;
        for (var i = 0; i < order.Length; i++) {
            for (var j = pos; j < array.Length; j++) {
                if (array[j] == order[i]) {
                    Swap (pos, j, array);
                    pos++;
                }
            }
        }

        return array;
    }

    private void Swap (int i, int j, int[] array) {
        var tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
}