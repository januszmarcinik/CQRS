using System;

namespace CQRS.Core
{
    public class MatchResult
    {
        private bool resultApplied;

        public Team HomeTeam { get; }
        public int HomeTeamGoals { get; }

        public Team AwayTeam { get; }
        public int AwayTeamGoals { get; }

        public MatchResult(Team homeTeam, int homeTeamGoals, Team awayTeam, int awayTeamGoals)
        {
            HomeTeam = homeTeam;
            HomeTeamGoals = homeTeamGoals;
            AwayTeam = awayTeam;
            AwayTeamGoals = awayTeamGoals;
            resultApplied = false;
        }

        public void ApplyResult(Team homeTeam, Team awayTeam)
        {
            if (resultApplied)
            {
                throw new InvalidOperationException("Match result is already applied.");
            }

            homeTeam.InsertResult(HomeTeamGoals, AwayTeamGoals);
            awayTeam.InsertResult(AwayTeamGoals, HomeTeamGoals);
            resultApplied = true;
        }
    }
}
