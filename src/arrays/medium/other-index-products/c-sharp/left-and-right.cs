using System;

/*
To improve our solution we could calculate the product of every element to the left, and the product of every element to the right of the current index. 
Do this with two loops through the array: one from left to right and one from right to left. 
Once that we have the products for everything to the left and to the right of the current index, we can multiply left * right, which gives us the total product.

Time : O(n) - Where N is the length of the input list (3N ~= N)
Space: O(n) - For the output list (3N ~= N)
*/
public class Program {
    public int[] ArrayOfProducts (int[] array) {
        var output = new int[array.Length];
        var leftProducts = new int[array.Length];
        var rightProducts = new int[array.Length];

        int currentLeft = 1;
        for (int i = 0; i < array.Length; i++) {
            leftProducts[i] = currentLeft;
            currentLeft *= array[i];
        }

        int currentRight = 1;
        for (int i = array.Length - 1; i >= 0; i--) {
            rightProducts[i] = currentRight;
            currentRight *= array[i];
        }

        for (int i = 0; i < array.Length; i++) {
            output[i] = leftProducts[i] * rightProducts[i];
        }

        return output;
    }
}