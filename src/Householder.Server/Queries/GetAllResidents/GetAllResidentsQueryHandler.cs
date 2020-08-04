using System.Collections.Generic;
using System.Threading.Tasks;
using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetAllResidentsQueryHandler : IQueryHandler<GetAllResidentsQuery, IEnumerable<Resident>>
    {
        public Task<IEnumerable<Resident>> Handle(GetAllResidentsQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}