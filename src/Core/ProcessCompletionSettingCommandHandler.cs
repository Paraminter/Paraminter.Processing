namespace Paraminter.Processing;

using Paraminter.Cqs;
using Paraminter.Processing.Commands;

/// <summary>Handles commands by setting the completion status.</summary>
/// <typeparam name="TQuery">The type of the handled commands.</typeparam>
public sealed class ProcessCompletionSettingCommandHandler<TQuery>
    : ICommandHandler<TQuery>
    where TQuery : ICommand
{
    private readonly ICommandHandler<ISetProcessCompletionCommand> CompletionSetter;

    /// <summary>Instantiates a command-handler which sets the completion status.</summary>
    /// <param name="completionSetter">Sets the completion status.</param>
    public ProcessCompletionSettingCommandHandler(
        ICommandHandler<ISetProcessCompletionCommand> completionSetter)
    {
        CompletionSetter = completionSetter ?? throw new System.ArgumentNullException(nameof(completionSetter));
    }

    void ICommandHandler<TQuery>.Handle(
        TQuery command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        CompletionSetter.Handle(SetProcessCompletionCommand.Instance);
    }
}
