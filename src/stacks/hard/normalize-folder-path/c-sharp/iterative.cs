using System;
using System.Linq;
using System.Collections.Generic;

/*
To solve this problem we split the input path around the directory separator "/" using a native split function, and we eliminate current directory "." or empty string representing "/" tokens from the resulting list of tokens. 
Using a stack we can implement the logic of chaging directory to the parent directory by parsing out the ".." token and removing the last element from the stack if it's a valid folder name, or if we are not at the root.

There are two relevant edge cases: 
 - absolute paths starting with "/" which we can handle at the beginning of the algorithm
 - relative paths that start with one or multiple ".." tokens, that we'll want to stack since they're meaningful to the resulting path

Time : O(n) - Where N is the length of the string path passed by parameter
Space: O(n) - To store the stack elements and the list of filtered tokens
*/
public class Program
{
    private const string DirectorySeparator = "/";
    private const string CurrentDirectory = ".";
    private const string PreviousDirectory = "..";
    private const string RootDirectory = "";

    public static string ShortenPath (string path)
    {
        var tokenList = path.Split (DirectorySeparator).ToList();
        var tokenFilter = tokenList.FindAll (token => IsValidDirectoryToken(token));
        var stack = new Stack<string>();

        // absolute path
        if (path[0] == '/')
        {
            stack.Push (RootDirectory);
        }

        foreach (var token in tokenFilter)
        {
            // current token is a folder name identifier
            if (token != PreviousDirectory)
            {
                stack.Push (token);
                continue;
            }
            // the path is relative and starts with ".." so we need to stack them
            if (stack.Count == 0 || stack.Peek() == PreviousDirectory)
            {
                stack.Push (token);
                continue;
            }
            // we need to "cd .." and we are not at the root dir "/"
            if (stack.Peek() != RootDirectory)
            {
                stack.Pop();
                continue;
            }
        }

        if (stack.Count == 1 && stack.Peek() == RootDirectory)
        {
            return DirectorySeparator;
        }

        var output = stack.ToArray();
        Array.Reverse (output);
        return string.Join (DirectorySeparator, output);
    }

    // Checks whether the token is equal to ".." or a valid folder name
    private static bool IsValidDirectoryToken (string token)
    {
        return token.Length > 0 && token != CurrentDirectory;
    }
}
