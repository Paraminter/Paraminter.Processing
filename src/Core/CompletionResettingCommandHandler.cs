namespace Paraminter.Processors;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

/// <summary>Handles commands by resetting the completion status of the process of associating arguments with parameters.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public sealed class CompletionResettingCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand> CompletionResetter;

    /// <summary>Instantiates a command-handler which resets the completion status of the process of associating arguments with parameters.</summary>
    /// <param name="completionResetter">Resets the completion status of the process of associating arguments with parameters.</param>
    public CompletionResettingCommandHandler(
        ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand> completionResetter)
    {
        CompletionResetter = completionResetter ?? throw new System.ArgumentNullException(nameof(completionResetter));
    }

    void ICommandHandler<TCommand>.Handle(
        TCommand command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        CompletionResetter.Handle(ResetProcessArgumentAssociationsCompletionCommand.Instance);
    }
}
