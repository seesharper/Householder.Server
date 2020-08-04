using System.Threading.Tasks;

namespace Householder.Server.Queries
{
    public interface IQueryProcessor
    {
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}