using System.Collections.Generic;

namespace CQRS.Core
{
    public interface IFootballService
    {
        IEnumerable<Team> GetTeams();

        void InsertResult(MatchResult matchResult);
    }
}
