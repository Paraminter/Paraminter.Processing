namespace Paraminter.Processors;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

/// <summary>Handles commands by setting the completion status of the process of associating arguments with parameters.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public sealed class CompletionSettingCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand> CompletionSetter;

    /// <summary>Instantiates a command-handler which sets the completion status of the process of associating arguments with parameters.</summary>
    /// <param name="completionSetter">Sets the completion status of the process of associating arguments with parameters.</param>
    public CompletionSettingCommandHandler(
        ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand> completionSetter)
    {
        CompletionSetter = completionSetter ?? throw new System.ArgumentNullException(nameof(completionSetter));
    }

    void ICommandHandler<TCommand>.Handle(
        TCommand command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        CompletionSetter.Handle(SetProcessArgumentAssociationsCompletionCommand.Instance);
    }
}
