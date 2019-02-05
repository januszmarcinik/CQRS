using System;
using CQRS.Common;

namespace CQRS.Core
{
    public class InsertMatchResultCommand : ICommand
    {
        public string HomeTeamName { get; }
        public int HomeTeamGoals { get; }

        public string AwayTeamName { get; }
        public int AwayTeamGoals { get; }

        public InsertMatchResultCommand(string homeTeamName, int homeTeamGoals, string awayTeamName, int awayTeamGoals)
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
    }
}
