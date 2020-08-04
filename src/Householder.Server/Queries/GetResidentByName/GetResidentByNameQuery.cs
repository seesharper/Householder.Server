using Householder.Server.Models;

namespace Householder.Server.Queries
{
    public class GetResidentByNameQuery : IQuery<Resident>
    {
        public string Name { get; }

        public GetResidentByNameQuery(string name)
        {
            Name = name;
        }
    }
}