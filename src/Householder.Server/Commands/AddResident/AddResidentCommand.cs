using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class AddResidentCommand : ICommand<long>
    {
        public Resident Resident { get; }

        public AddResidentCommand(Resident resident)
        {
            Resident = resident;
        }
    }
}