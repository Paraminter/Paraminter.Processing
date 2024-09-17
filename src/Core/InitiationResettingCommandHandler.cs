namespace Paraminter.Processors;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

/// <summary>Handles commands by resetting the initiation status of the process of associating arguments with parameters.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public sealed class InitiationResettingCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand> InitiationResetter;

    /// <summary>Instantiates a command-handler which resets the initiation status of the process of associating arguments with parameters.</summary>
    /// <param name="initiationResetter">Resets the initiation status of the process of associating arguments with parameters.</param>
    public InitiationResettingCommandHandler(
        ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand> initiationResetter)
    {
        InitiationResetter = initiationResetter ?? throw new System.ArgumentNullException(nameof(initiationResetter));
    }

    void ICommandHandler<TCommand>.Handle(
        TCommand command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        InitiationResetter.Handle(ResetProcessArgumentAssociationsInitiationCommand.Instance);
    }
}
