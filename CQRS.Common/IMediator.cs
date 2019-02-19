namespace CQRS.Common
{
    public interface IMediator
    {
        void Command<TCommand>(TCommand command) where TCommand : ICommand;

        TResponse Query<TResponse>(IQuery<TResponse> query);

        TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;
    }
}
