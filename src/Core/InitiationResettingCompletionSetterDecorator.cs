namespace Paraminter.Processors;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

using System;

/// <summary>Decorates a setter of the completion status of the process of associating arguments with parameters by resetting the initiation status beforehand.</summary>
public sealed class InitiationResettingCompletionSetterDecorator
    : ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>
{
    private readonly ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand> Decoratee;
    private readonly ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand> InitiationResetter;

    /// <summary>Instantiates a decorator of a setter of the completion status of the process of associating arguments with parameters, which resets the initiation status beforehand.</summary>
    /// <param name="decoratee">The decorated setter of the completion status of the process of associating arguments with parameters.</param>
    /// <param name="initiationResetter">Resets the initiation status of the process of associating arguments with parameters.</param>
    public InitiationResettingCompletionSetterDecorator(
        ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand> decoratee,
        ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand> initiationResetter)
    {
        Decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        InitiationResetter = initiationResetter ?? throw new ArgumentNullException(nameof(initiationResetter));
    }

    void ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>.Handle(
        ISetProcessArgumentAssociationsCompletionCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        InitiationResetter.Handle(ResetProcessArgumentAssociationsInitiationCommand.Instance);

        Decoratee.Handle(command);
    }
}
