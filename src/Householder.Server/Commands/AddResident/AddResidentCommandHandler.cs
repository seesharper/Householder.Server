using System.Threading.Tasks;
using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class AddResidentCommandHandler : ICommandHandler<AddResidentCommand, Resident>
    {
        public Task<Resident> Handle(AddResidentCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}