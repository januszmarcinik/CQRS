using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Core
{
    public interface IFootballRepository
    {
        IEnumerable<Team> Query(Func<IQueryable<Team>, IQueryable<Team>> query);

        Team GetTeam(string name);

        void Save(MatchResult matchResult);
    }
}
