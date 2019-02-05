using System;

namespace CQRS.Core
{
    public class MatchResult
    {
        public string HomeTeamName { get; }
        public int HomeTeamGoals { get; }

        public string AwayTeamName { get; }
        public int AwayTeamGoals { get; }

        public MatchResult(string homeTeamName, int homeTeamGoals, string awayTeamName, int awayTeamGoals)
        {
            if (string.IsNullOrWhiteSpace(homeTeamName)) throw new ArgumentException(nameof(homeTeamName));
            HomeTeamName = homeTeamName;

            if (homeTeamGoals < 0) throw new ArgumentException(nameof(homeTeamGoals));
            HomeTeamGoals = homeTeamGoals;

            if (string.IsNullOrWhiteSpace(awayTeamName)) throw new ArgumentException(nameof(awayTeamName));
            AwayTeamName = awayTeamName;

            if (awayTeamGoals < 0) throw new ArgumentException(nameof(awayTeamGoals));
            AwayTeamGoals = awayTeamGoals;
        }

        public void ApplyTo(Team homeTeam, Team awayTeam)
        {
            homeTeam.InsertResult(HomeTeamGoals, AwayTeamGoals);
            awayTeam.InsertResult(AwayTeamGoals, HomeTeamGoals);
        }
    }
}
