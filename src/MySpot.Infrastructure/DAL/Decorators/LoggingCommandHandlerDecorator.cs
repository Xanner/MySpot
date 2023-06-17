using MySpot.Application.Abstractions;

namespace MySpot.Infrastructure.DAL.Decorators;

internal sealed class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    private readonly ICommandHandler<TCommand> _commandHandler;

    public LoggingCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler)
    {
        _commandHandler = commandHandler;
    }
    public async Task HandleAsync(TCommand command)
    {
        Console.WriteLine($"Processing a command: {command.GetType().Name}");
        await _commandHandler.HandleAsync(command);
    }
}