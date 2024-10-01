namespace Paraminter.Processing;

using Paraminter.Cqs;
using Paraminter.Processing.Commands;

/// <summary>Handles commands by resetting the completion status.</summary>
/// <typeparam name="TQuery">The type of the handled commands.</typeparam>
public sealed class ProcessCompletionResettingCommandHandler<TQuery>
    : ICommandHandler<TQuery>
    where TQuery : ICommand
{
    private readonly ICommandHandler<IResetProcessCompletionCommand> CompletionResetter;

    /// <summary>Instantiates a command-handler which resets the completion status.</summary>
    /// <param name="completionResetter">Resets the completion status.</param>
    public ProcessCompletionResettingCommandHandler(
        ICommandHandler<IResetProcessCompletionCommand> completionResetter)
    {
        CompletionResetter = completionResetter ?? throw new System.ArgumentNullException(nameof(completionResetter));
    }

    void ICommandHandler<TQuery>.Handle(
        TQuery command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        CompletionResetter.Handle(ResetProcessCompletionCommand.Instance);
    }
}
