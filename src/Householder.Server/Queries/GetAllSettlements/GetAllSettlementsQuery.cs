using System.Collections.Generic;
using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetAllSettlementsQuery : IQuery<IEnumerable<Settlement>>
    {
        public int Limit { get; }

        public GetAllSettlementsQuery(int limit)
        {
            Limit = limit;
        }
    }
}