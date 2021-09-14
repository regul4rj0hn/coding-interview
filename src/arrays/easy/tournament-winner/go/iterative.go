package main

const HOME_TEAM_WON = 1

func TournamentWinner(competitions [][]string, results []int) string {
	winner := ""
	scores := map[string]int{winner: 0}

	for i, competition := range competitions {
		result := results[i]
		homeTeam, awayTeam := competition[0], competition[1]

		winningTeam := awayTeam
		if result == HOME_TEAM_WON {
			winningTeam = homeTeam
		}

		updateScores(winningTeam, 3, scores)

		if scores[winningTeam] > scores[winner] {
			winner = winningTeam
		}
	}
	return winner
}

func updateScores(team string, points int, scores map[string]int) {
	scores[team] += points
}
