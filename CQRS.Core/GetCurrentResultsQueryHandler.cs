using System.Collections.Generic;
using System.Linq;
using CQRS.Common;

namespace CQRS.Core
{
    public class GetCurrentResultsQueryHandler : IQueryHandler<GetCurrentResultsQuery, IEnumerable<Team>>
    {
        private readonly IFootballRepository repository;

        public GetCurrentResultsQueryHandler(IFootballRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Team> Handle(GetCurrentResultsQuery query)
        {
            var result = repository.Query(q => q
                    .OrderByDescending(x => x.Points)
                    .ThenByDescending(x => x.GoalsBalance))
                .ToList();

            return result;
        }
    }
}
