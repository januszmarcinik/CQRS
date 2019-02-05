using System.Collections.Generic;
using CQRS.Common;

namespace CQRS.Core
{
    public class GetCurrentResultsQuery : IQuery<IEnumerable<Team>>
    {
    }
}
