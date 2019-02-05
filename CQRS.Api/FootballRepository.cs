using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Core;

namespace CQRS.Api
{
    internal class FootballRepository : IFootballRepository
    {
        private readonly EfContext context;

        public FootballRepository(EfContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        public IEnumerable<Team> Query(Func<IQueryable<Team>, IQueryable<Team>> query)
            => query(context.Teams);

        public Team GetTeam(string name)
            => context.Teams.Find(name);

        public void Save(MatchResult matchResult)
        {
            context.Teams.Update(matchResult.HomeTeam);
            context.Teams.Update(matchResult.AwayTeam);
            context.SaveChanges();
        }
    }
}
