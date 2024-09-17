namespace Paraminter.Processors;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

using System;

/// <summary>Decorates a setter of the initiation status of the process of associating arguments with parameters by resetting the completion status beforehand.</summary>
public sealed class CompletionResettingInitiationSetterDecorator
    : ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>
{
    private readonly ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand> Decoratee;
    private readonly ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand> CompletionResetter;

    /// <summary>Instantiates a decorator of a setter of the initiation status of the process of associating arguments with parameters, which resets the completion status beforehand.</summary>
    /// <param name="decoratee">The decorated setter of the initiation status of the process of associating arguments with parameters.</param>
    /// <param name="completionResetter">Resets the completion status of the process of associating arguments with parameters.</param>
    public CompletionResettingInitiationSetterDecorator(
        ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand> decoratee,
        ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand> completionResetter)
    {
        Decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        CompletionResetter = completionResetter ?? throw new ArgumentNullException(nameof(completionResetter));
    }

    void ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>.Handle(
        ISetProcessArgumentAssociationsInitiationCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        CompletionResetter.Handle(ResetProcessArgumentAssociationsCompletionCommand.Instance);

        Decoratee.Handle(command);
    }
}
