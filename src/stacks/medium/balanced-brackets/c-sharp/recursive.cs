using System;

/*
The strategy is the same as the iterative approach, this seems neater and doesn't use an actual stack data structure but it might be worse memory wise (call stack)

Time : O(n) - Where N is the length of the input string, worst case when it is balanced we have to go through the whole string.
Space: O(n) - Recursive function call stack
*/
public class Program {

    private static string Open = "([<{";
    private static string Close = ")]>}";

    public static bool BalancedBrackets (string str) {
        return IsBalanced (str, string.Empty);
    }

    private static bool IsBalanced (string input, string stack) {
        if (string.IsNullOrEmpty (input)) {
            return string.IsNullOrEmpty (stack);
        }
        if (Open.IndexOf (input[0]) != -1) {
            return IsBalanced (input.Substring (1), input[0] + stack);
        }
        if (Close.IndexOf (input[0]) != -1) {
            return !string.IsNullOrEmpty (stack) &&
                Open.IndexOf (stack[0]) == Close.IndexOf (input[0]) &&
                IsBalanced (input.Substring (1), stack.Substring (1));
        }
        return IsBalanced (input.Substring (1), stack);
    }
}