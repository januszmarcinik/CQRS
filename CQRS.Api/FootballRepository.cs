using CQRS.Core;

namespace CQRS.Api
{
    internal class FootballRepository : IFootballRepository
    {
        private readonly EfContext context;

        public FootballRepository(EfContext context)
        {
            this.context = context;
        }

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
