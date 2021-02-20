using System;
using System.Collections.Generic;

/*
Basic strategy is when an opening bracket is found, push it on the stack, skip everything else except for closing brackets. When a closing bracket is found and matches the last opening one, pop it from the stack. Otherwise the brackets are not balanced. 

Time : O(n) - Where N is the length of the input string, worst case when it is balanced we have to go through the whole string.
Space: O(n) - Worst case is actually N/2, the space for the stack
*/
public class Program {
    public static bool BalancedBrackets (string str) {
        var isBalanced = true;
        var index = 0;
        var stack = new Stack<char> ();

        while (isBalanced && index < str.Length) {
            var currentChar = str[index];
            if (IsOpeningBracket (currentChar)) {
                stack.Push (currentChar);
            }
            else if (IsClosingBracket (currentChar)) {
                var lastBracket = stack.Count > 0 ? stack.Pop () : ' ';
                isBalanced = IsValidClosing (lastBracket, currentChar);
            }
            index++;
        }

        return isBalanced && stack.Count == 0;
    }

    private static bool IsOpeningBracket (char c) {
        return c == '(' || c == '[' || c == '{';
    }

    private static bool IsClosingBracket (char c) {
        return c == ')' || c == ']' || c == '}';
    }

    private static bool IsValidClosing (char open, char close) {
        if (open == '(' && close == ')') {
            return true;
        }
        if (open == '[' && close == ']') {
            return true;
        }
        if (open == '{' && close == '}') {
            return true;
        }
        return false;
    }
}