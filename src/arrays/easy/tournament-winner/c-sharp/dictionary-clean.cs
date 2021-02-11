using System;
using System.Collections.Generic;

/*
Time : O(n) - Where N is the length of the matches that were played inside competitions (assuming constant search)
Space: O(k) - For the dictionary scoreboard, where K is the total number of teams
*/
public class Program {

    private readonly int LOCAL_WINS = 1;

    public string TournamentWinner (List<List<string>> competitions, List<int> results) {
        var winner = string.Empty;
        var scoreboard = new Dictionary<string, int> () { };
        scoreboard.Add (winner, 0);
        int matchNumber = 0;

        foreach (var match in competitions) {
            string local = match[0];
            string visitor = match[1];
            string matchWinner = results[matchNumber] == LOCAL_WINS ? local : visitor;

            UpdateScoreboard (scoreboard, matchWinner, 3);

            if (scoreboard[matchWinner] > scoreboard[winner]) {
                winner = matchWinner;
            }

            matchNumber++;
        }

        return winner;
    }

    private static void UpdateScoreboard (Dictionary<string, int> scoreboard, string winner, int points) {
        if (!scoreboard.ContainsKey (winner)) {
            scoreboard.Add (winner, 3);
        }
        else {
            scoreboard[winner] = scoreboard[winner] + points;
        }
    }
}