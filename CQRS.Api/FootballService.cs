using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Core;

namespace CQRS.Api
{
    internal class FootballService : IFootballService
    {
        private readonly EfContext context;

        public FootballService(EfContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        public IEnumerable<Team> GetTeams()
            => context.Teams
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalsBalance)
                .ToList();

        public void InsertResult(MatchResult matchResult)
        {
            var homeTeam = context.Teams.Find(matchResult.HomeTeamName);
            if (homeTeam == null)
            {
                throw new NullReferenceException($"Given team '{matchResult.HomeTeamName}' does not exists.");
            }

            var awayTeam = context.Teams.Find(matchResult.AwayTeamName);
            if (awayTeam == null)
            {
                throw new NullReferenceException($"Given team '{matchResult.AwayTeamName}' does not exists.");
            }

            matchResult.ApplyTo(homeTeam, awayTeam);

            context.Teams.UpdateRange(homeTeam, awayTeam);
            context.SaveChanges();
        }
    }
}
