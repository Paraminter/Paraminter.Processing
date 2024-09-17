namespace Paraminter.Processors;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

/// <summary>Handles commands by setting the initiation status of the process of associating arguments with parameters.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public sealed class InitiationSettingCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand> InitiationSetter;

    /// <summary>Instantiates a command-handler which sets the initiation status of the process of associating arguments with parameters.</summary>
    /// <param name="initiationSetter">Sets the initiation status of the process of associating arguments with parameters.</param>
    public InitiationSettingCommandHandler(
        ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand> initiationSetter)
    {
        InitiationSetter = initiationSetter ?? throw new System.ArgumentNullException(nameof(initiationSetter));
    }

    void ICommandHandler<TCommand>.Handle(
        TCommand command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        InitiationSetter.Handle(SetProcessArgumentAssociationsInitiationCommand.Instance);
    }
}
