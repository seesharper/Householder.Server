using Householder.Server.Models;

namespace Householder.Server.Commands
{
    public class AddReconciliationCommand : ICommand<long>
    {
        public Reconciliation Reconciliation { get; }

        public AddReconciliationCommand(Reconciliation reconciliation)
        {
            Reconciliation = reconciliation;
        }
        
    }
}