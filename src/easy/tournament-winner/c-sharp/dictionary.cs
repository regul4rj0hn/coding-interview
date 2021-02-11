using System;
using System.Collections.Generic;
using System.Linq;

/*
Time : O(n) - Where N is the length of the matches that were played inside competitions (assuming constant search)
Space: O(k) - For the dictionary scoreboard, where K is the total number of teams
*/
public class Program {
    public string TournamentWinner (List<List<string>> competitions, List<int> results) {
        var scoreboard = new Dictionary<string, int> () { };
        int matchNumber = 0;

        foreach (var match in competitions) {
            string local = match[0];
            string visitor = match[1];
            // Visitor wins
            if (results[matchNumber] == 0) {
                if (!scoreboard.ContainsKey (visitor)) {
                    scoreboard.Add (visitor, 1);
                }
                else {
                    scoreboard[visitor] = scoreboard[visitor] + 1;
                }
            }
            // Local wins - same thing, can be extracted to a function
            else {
                if (!scoreboard.ContainsKey (local)) {
                    scoreboard.Add (local, 1);
                }
                else {
                    scoreboard[local] = scoreboard[local] + 1;
                }
            }
            matchNumber++;
        }

        // Get the team with the max number of wins from the scoreboard of winners
        // It would be better to just keep track of the current winner as we loop
        return scoreboard.FirstOrDefault (x => x.Value == scoreboard.Values.Max ()).Key;
    }
}