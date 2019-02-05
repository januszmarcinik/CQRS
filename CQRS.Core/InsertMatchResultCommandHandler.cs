using System;
using CQRS.Common;

namespace CQRS.Core
{
    public class InsertMatchResultCommandHandler : ICommandHandler<InsertMatchResultCommand>
    {
        private readonly IFootballRepository repository;

        public InsertMatchResultCommandHandler(IFootballRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(InsertMatchResultCommand command)
        {
            var homeTeam = repository.GetTeam(command.HomeTeamName);
            if (homeTeam == null)
            {
                throw new NullReferenceException($"Given team '{command.HomeTeamName}' does not exists.");
            }

            var awayTeam = repository.GetTeam(command.AwayTeamName);
            if (awayTeam == null)
            {
                throw new NullReferenceException($"Given team '{command.AwayTeamName}' does not exists.");
            }

            var matchResult = new MatchResult(homeTeam, command.HomeTeamGoals, awayTeam, command.AwayTeamGoals);
            matchResult.ApplyResult(homeTeam, awayTeam);

            repository.Save(matchResult);
        }
    }
}
