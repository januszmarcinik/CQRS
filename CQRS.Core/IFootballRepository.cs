namespace CQRS.Core
{
    public interface IFootballRepository
    {
        Team GetTeam(string name);

        void Save(MatchResult matchResult);
    }
}
