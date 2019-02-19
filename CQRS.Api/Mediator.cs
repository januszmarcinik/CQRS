using System;
using System.Linq;
using CQRS.Common;
using CQRS.Core;

namespace CQRS.Api
{
    internal class Mediator : IMediator
    {
        private readonly IFootballRepository repository;

        public Mediator(IFootballRepository repository)
        {
            this.repository = repository;
        }

        public void Command<TCommand>(TCommand command) where TCommand : ICommand
        {
            switch (command)
            {
                case InsertMatchResultCommand c:
                    new InsertMatchResultCommandHandler(repository).Handle(c);
                    break;
                default:
                    throw new InvalidOperationException($"Command of type '{command.GetType()}' has not registered handler.");
            }
        }

        public TResponse Query<TResponse>(IQuery<TResponse> query)
        {
            return (TResponse) GetType()
                .GetMethods()
                .First(x => x.Name == "Query" && x.GetGenericArguments().Length == 2)
                .MakeGenericMethod(query.GetType(), typeof(TResponse))
                .Invoke(this, new object[] {query});
        }

        public TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>
        {
            switch (query)
            {
                case GetCurrentResultsQuery q:
                    return (TResponse)new GetCurrentResultsQueryHandler(repository).Handle(q);
                default:
                    throw new InvalidOperationException($"Query of type '{query.GetType()}' has not registered handler.");
            }
        }
    }
}
