using System;

/*
Time : O(n) - Calculate once all fibs for N
Space: O(1) - Constant space, just storing the last 2 values
*/
public class Program {
    public static int GetNthFib (int n) {
        int[] fib = { 0, 1 };

        for (int i = 3; i <= n; i++) {
            int next = fib[0] + fib[1];
            fib[0] = fib[1];
            fib[1] = next;
        }

        return n > 1 ? fib[1] : fib[0];
    }
}