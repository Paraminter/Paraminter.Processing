namespace Paraminter.Processing;

using Paraminter.Cqs;
using Paraminter.Processing.Commands;

/// <summary>Handles commands by resetting the initiation status.</summary>
/// <typeparam name="TQuery">The type of the handled commands.</typeparam>
public sealed class ProcessInitiationResettingCommandHandler<TQuery>
    : ICommandHandler<TQuery>
    where TQuery : ICommand
{
    private readonly ICommandHandler<IResetProcessInitiationCommand> InitiationResetter;

    /// <summary>Instantiates a command-handler which resets the initiation status.</summary>
    /// <param name="initiationResetter">Resets the initiation status.</param>
    public ProcessInitiationResettingCommandHandler(
        ICommandHandler<IResetProcessInitiationCommand> initiationResetter)
    {
        InitiationResetter = initiationResetter ?? throw new System.ArgumentNullException(nameof(initiationResetter));
    }

    void ICommandHandler<TQuery>.Handle(
        TQuery command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        InitiationResetter.Handle(ResetProcessInitiationCommand.Instance);
    }
}
