using System;

/*
Time : O(2^n) - Each fib calls 2 fibs so 2*2 N times
Space: O(n)   - Function call stack stores N frames before it starts returning (trace and it's obvious)
*/
public class Program {
    public static int GetNthFib (int n) {
        if (n == 1) {
            return 0;
        }
        if (n == 2) {
            return 1;
        }
        else {
            return GetNthFib (n - 1) + GetNthFib (n - 2);
        }
    }
}