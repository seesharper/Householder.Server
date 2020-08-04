using System.Collections.Generic;
using System.Threading.Tasks;
using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetResidentByNameQueryHandler : IQueryHandler<GetResidentByNameQuery, Resident>
    {
        public Task<Resident> Handle(GetResidentByNameQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}