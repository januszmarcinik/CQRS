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
    }
}
