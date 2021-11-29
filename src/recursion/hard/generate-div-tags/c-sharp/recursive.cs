using System.Collections.Generic;
using System;

public class Program {

    public List<string> GenerateDivTags(int numberOfTags) {
        var matchedTags = new List<string>();
        GenerateDivTagsFromPrefix(numberOfTags, numberOfTags, "", matchedTags);
        return matchedTags;
    }
    
    private void GenerateDivTagsFromPrefix(int opening, int closing, string prefix, List<string> output) {
        if (opening > 0) {
            var newPrefix = prefix + "<div>";
            GenerateDivTagsFromPrefix(opening - 1, closing, newPrefix, output);
        }
        if (opening < closing) {
            var newPrefix = prefix + "</div>";
            GenerateDivTagsFromPrefix(opening, closing - 1, newPrefix, output);
        }
        if (closing == 0) {
            output.Add(prefix);
        }
    }
}
