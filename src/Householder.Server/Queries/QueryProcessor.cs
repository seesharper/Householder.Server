using LightInject;
using System.Threading.Tasks;

namespace Householder.Server.Queries
{
    public class QueryProcessor : IQueryProcessor
    {
        private IServiceContainer container;

        public QueryProcessor(IServiceContainer container)
        {
            this.container = container;
        }
        
        public async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = container.GetInstance(handlerType);

            return await handler.Handle((dynamic)query);
        }
    }
}